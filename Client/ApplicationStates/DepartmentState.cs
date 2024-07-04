﻿namespace Client.ApplicationStates
{
    public class DepartmentState
    {
        public Action? GeneralDepartmentAction { get; set; }
        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentCliked()
        {
            ResetAllDepartment();
            ShowGeneralDepartment = true;
            GeneralDepartmentAction?.Invoke();
        }
        private void ResetAllDepartment()
        {
            ShowGeneralDepartment = false;
        }
    }
}
