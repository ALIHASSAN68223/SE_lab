using AgriProductsManagementSystem.DataAccess;
using AgriProductsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AgriProductsManagementSystem.ViewModels
{
    internal class DealerAddEmployeeViewModel
    {
        private string firstName;
        private string lastName;
        private string username;
        private string email;
        private string password;
        private string schedule;
        private decimal? salary;
        private bool isExpert;

        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                if (value != username)
                {
                    username = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Schedule
        {
            get { return schedule; }
            set
            {
                if (value != schedule)
                {
                    schedule = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal? Salary
        {
            get { return salary; }
            set
            {
                if (value != salary)
                {
                    salary = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsExpert
        {
            get { return isExpert; }
            set
            {
                if (value != isExpert)
                {
                    isExpert = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly AppDbContext dbContext;

        public DealerAddEmployeeViewModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddEmployee()
        {
            try
            {
                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
                {
                    // Here, we provide detailed information about the missing fields
                    StringBuilder missingFieldsMessage = new StringBuilder("Please fill in these required missing fields:\n");

                    if (string.IsNullOrEmpty(FirstName))
                    {
                        missingFieldsMessage.AppendLine("- First Name");
                    }

                    if (string.IsNullOrEmpty(Username))
                    {
                        missingFieldsMessage.AppendLine("- Username");
                    }

                    if (string.IsNullOrEmpty(Password))
                    {
                        missingFieldsMessage.AppendLine("- Password");
                    }

                    if (string.IsNullOrEmpty(Email))
                    {
                        missingFieldsMessage.AppendLine("- Email");
                    }

                    MessageBox.Show(missingFieldsMessage.ToString(), "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);

                    return;
                }
                var employee = new Employee
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Username = Username,
                    Password = Password, // Make sure to handle password securely (hashing, etc.)
                    Email = Email,
                    Active = true,
                    CreatedAt = DateTime.UtcNow.AddHours(5),
                    UpdatedAt = DateTime.UtcNow.AddHours(5),
                    IsExpert = IsExpert,
                    Salary = Salary,
                    Schedule = Schedule
                };

                // Call to data access layer to save the new employee to the database
                dbContext.AddEmployee(employee);
                // Call to data access layer to save the new employee to the database

                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during adding employee: {ex.Message}");
                // Print inner exceptions if available
                Exception innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine($"Inner Exception: {innerException.Message}");
                    innerException = innerException.InnerException;
                }
            }

        }
    }
}
