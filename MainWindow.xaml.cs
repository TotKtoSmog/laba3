using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Controls;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;

namespace laba3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee[] employees;
        List<DepartmentStatistic> departmentStatistics;
        public SeriesCollection DepartamentStatisticSeriesViews { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            employees = getStudentInfo();
            FillDataGirdView(employees);
            departmentStatistics = FillingDepartmentStatistic(employees);
            DepartamentStatisticSeriesViews = CreateDepartamentStatisticPieChart();
            DataContext = this;
            multiEmpl.ItemsSource = employees.Where(n => n.Jobs.Count( j => j.endDate == "") > 1);
            DepartmentList.ItemsSource = departmentStatistics.Where(n => n.countEmployees <= 3).Select(n => n.department);
            getMaxAceptAndDismissed();
            Console.WriteLine();
        }
        public Employee[] getStudentInfo()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Employee[]));
            Employee[] employees;
            using (FileStream fs = new FileStream("C:\\Users\\Totkt\\Desktop\\student.xml", FileMode.OpenOrCreate))
            {
                employees = formatter.Deserialize(fs) as Employee[];
            }
            return employees;
        }
        public void FillDataGirdView(Employee[] employees)
        {
            EmployeesTable.ItemsSource = employees;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Employee[] emps = employees.Where(n => n.FIO.Contains(SearchEmployees.Text)).ToArray();
            EmployeesTable.ItemsSource = emps;
            FillingOrder(emps.First());
        }

        private void SearchEmployees_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Employee[] emps = employees.Where(n => n.FIO.Contains(SearchEmployees.Text)).ToArray();
            EmployeesTable.ItemsSource = emps;
            if (emps.Length == 1)
                FillingOrder(emps.First());
            else
               Report.Visibility = Visibility.Hidden;

        }
        public void FillingOrder(Employee employees)
        {
            Report.Visibility = Visibility.Visible;
            FIO.Text = employees.FIO;
            yearOfBirth.Text = employees.yearOfBirth;
            address.Text = employees.address;
            phone.Text = employees.phone;
            JobsTable.ItemsSource = employees.Jobs;
            SalaryTable.ItemsSource = employees.Salarys;
        }

        private void SalaryDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int year = SalaryDatePicker.DisplayDate.Year;
            Employee a = employees.Where(n => n.FIO.Contains(SearchEmployees.Text)).First();
            SalaryTable.ItemsSource = employees.Where(n => n.FIO.Contains(SearchEmployees.Text)).First().Salarys.Where(n => n.year == year);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
            => SalaryTable.ItemsSource = employees.Where(n => n.FIO.Contains(SearchEmployees.Text)).First().Salarys;

        private List<DepartmentStatistic> FillingDepartmentStatistic(Employee[] employees)
        {
            List<DepartmentStatistic> statistics = new List<DepartmentStatistic>();
            foreach (Employee employee in employees)
            {
                List<Job> jobs = employee.Jobs;
                foreach (Job job in jobs)
                {
                    if(statistics.Where(n => n.department == job.department).Count() < 1)
                        statistics.Add(new DepartmentStatistic(job.department, job.name));
                    else if (statistics.Where(n => n.post.Contains(job.name)).Count() == 0)
                        statistics.Where(n => n.department == job.department).First().post.Add(job.name);
                    if (job.endDate == "")
                        statistics.Where(n => n.department == job.department).First().countEmployees++;
                    statistics.Where(n => n.department == job.department).First().allCountEmployees++;
                }
            }
            DepartamentStatisticTable.ItemsSource = statistics;
            return statistics;
            
        }

        private SeriesCollection CreateDepartamentStatisticPieChart()
        {
            SeriesCollection s = new SeriesCollection();
            for (int i = 0; i < departmentStatistics.Count; i++)
            {
                s.Add(new PieSeries
                {
                    Title = departmentStatistics[i].department,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(departmentStatistics[i].countEmployees) },
                    DataLabels = true
                });
            }
            return s;
        }
        
        private List<Job> getAllJobs() 
        {
            List<Job> jTemp = new List<Job>();
            foreach (List<Job> job in employees.Select(n => n.Jobs).ToList())
            {
                foreach (Job job2 in job)
                    jTemp.Add(job2);
            }
            return jTemp;
        }
        private void getMaxAceptAndDismissed()
        {
            List<Job> jTemp = getAllJobs();
            var a = jTemp.GroupBy(n => n.department).Select(g => new { department = g.Key, Acept = g.Select(n => n.startDate).Count(), dismissed = g.Where(n => n.endDate != "").Count() });
            MaxAcept.Text = a.OrderByDescending(n => n.Acept).First().department;
            MaxDismissed.Text = a.OrderByDescending(n => n.dismissed).First().department;
        }

    }
}
