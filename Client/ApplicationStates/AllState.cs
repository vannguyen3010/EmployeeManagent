namespace Client.ApplicationStates
{
    public class AllState
    {
        //Scope action
        public Action? Action { get; set; }
        
        //General Department

        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentClicked()
        {
            ResetAllDepartment();
            ShowGeneralDepartment = true;
            Action?.Invoke();
        }

        //Department
        public bool ShowDepartment { get; set; }
        public void DepartmentClicked()
        {
            ResetAllDepartment();
            ShowDepartment = true;
            Action?.Invoke();
        }
        //Branch
        public bool ShowBranch { get; set; }
        public void BranchClicked()
        {
            ResetAllDepartment();
            ShowBranch = true;
            Action?.Invoke();
        }

        //Coutry
        public bool ShowCountry { get; set; }
        public void CountryClicked()
        {
            ResetAllDepartment();
            ShowCountry = true;
            Action?.Invoke();
        }

        //City
        public bool ShowCity{ get; set; }
        public void CityClicked()
        {
            ResetAllDepartment();
            ShowCity = true;
            Action?.Invoke();
        }

        //City
        public bool ShowTown { get; set; }
        public void TownClicked()
        {
            ResetAllDepartment();
            ShowTown = true;
            Action?.Invoke();
        }

        //User
        public bool ShowUser { get; set; }
        public void UserTownClicked()
        {
            ResetAllDepartment();
            ShowUser = true;
            Action?.Invoke();
        }

        //Doctor
        public bool ShowHealth { get; set; }
        public void HealthClicked()
        {
            ResetAllDepartment();
            ShowHealth = true;
            Action?.Invoke();
        }

        //Overtime
        public bool ShowOverTime { get; set; }
        public void OvertimeClicked()
        {
            ResetAllDepartment();
            ShowOverTime = true;
            Action?.Invoke();
        }

        //Overtime Type
        public bool ShowOverTimeType { get; set; }
        public void OvertimeTypeClicked()
        {
            ResetAllDepartment();
            ShowOverTimeType = true;
            Action?.Invoke();
        }

        //Saction
        public bool ShowSaction { get; set; }
        public void SactionClicked()
        {
            ResetAllDepartment();
            ShowSaction = true;
            Action?.Invoke();
        }

        //Saction Type
        public bool ShowSactionType { get; set; }
        public void SactionTypeClicked()
        {
            ResetAllDepartment();
            ShowSactionType = true;
            Action?.Invoke();
        }

        //Vacation
        public bool ShowVacation { get; set; }
        public void VacationClicked()
        {
            ResetAllDepartment();
            ShowVacation = true;
            Action?.Invoke();
        }

        //Vacation Type
        public bool ShowVacationType { get; set; }
        public void VacationTypeClicked()
        {
            ResetAllDepartment();
            ShowVacationType = true;
            Action?.Invoke();
        }

        //Employee
        public bool ShowEmployee { get; set; } = true;
        public void EmployeeTownClicked()
        {
            ResetAllDepartment();
            ShowEmployee = true;
            Action?.Invoke();
        }

        private void ResetAllDepartment()
        {
            ShowGeneralDepartment = false;
            ShowDepartment = false;
            ShowBranch = false;
            ShowCountry = false;
            ShowCity = false;
            ShowTown = false;
            ShowUser = false;
            ShowEmployee = false;
            ShowHealth = false;
            ShowOverTime = false;
            ShowSaction = false;
            ShowVacation = false;
            ShowOverTimeType = false;
            ShowVacationType = false;
            ShowSactionType = false;
        }
    }
}
