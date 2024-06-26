﻿namespace Cliente.ApplicationStates
{
    public class AllState
    {
        public Action? Action { get; set; }
        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentClick()
        {
            ResetAllDepartments();
            ShowGeneralDepartment = true;
            Action?.Invoke();
        }

		public bool ShowDepartment { get; set; }
		public void DepartmentClick()
		{
			ResetAllDepartments();
			ShowDepartment = true;
			Action?.Invoke();
		}

		public bool ShowBranch { get; set; }
		public void BranchClick()
		{
			ResetAllDepartments();
			ShowBranch = true;
			Action?.Invoke();
		}

		public bool ShowCountry { get; set; }
		public void CountryClick()
		{
			ResetAllDepartments();
			ShowCountry = true;
			Action?.Invoke();
		}

		public bool ShowCity { get; set; }
		public void CityClick()
		{
			ResetAllDepartments();
			ShowCity = true;
			Action?.Invoke();
		}

		public bool ShowTown { get; set; }
		public void TownClick()
		{
			ResetAllDepartments();
			ShowTown = true;
			Action?.Invoke();
		}

		public bool ShowUser { get; set; }
		public void UserClick()
		{
			ResetAllDepartments();
			ShowUser = true;
			Action?.Invoke();
		}

		public bool ShowEmployee { get; set; } = true;
		public void EmployeeClick()
		{
			ResetAllDepartments();
			ShowEmployee = true;
			Action?.Invoke();
		}

        public bool ShowHealth { get; set; }
        public void HealthClick()
        {
            ResetAllDepartments();
            ShowHealth = true;
            Action?.Invoke();
        }

        public bool ShowOvertimeType { get; set; }
        public void OvertimeTypeClick()
        {
            ResetAllDepartments();
            ShowOvertimeType = true;
            Action?.Invoke();
        }

        public bool ShowOvertime { get; set; }
        public void OvertimeClick()
        {
            ResetAllDepartments();
            ShowOvertime = true;
            Action?.Invoke();
        }

        public bool ShowSanctionType { get; set; }
        public void SanctionTypeClick()
        {
            ResetAllDepartments();
            ShowSanctionType = true;
            Action?.Invoke();
        }


        public bool ShowSanction { get; set; }
        public void SanctionClick()
        {
            ResetAllDepartments();
            ShowSanction = true;
            Action?.Invoke();
        }

        public bool ShowVacationType { get; set; }
        public void VacationTypeClick()
        {
            ResetAllDepartments();
            ShowVacationType = true;
            Action?.Invoke();
        }

        public bool ShowVacation { get; set; }
        public void VacationClick()
        {
            ResetAllDepartments();
            ShowVacation = true;
            Action?.Invoke();
        }


        private void ResetAllDepartments()
        {
            ShowGeneralDepartment = false;
			ShowDepartment = false;
			ShowBranch = false;
			ShowCountry = false;
			ShowCity = false;
			ShowTown = false;
			ShowUser = false;
			ShowEmployee = false;

            ShowVacationType = false;
            ShowVacation = false;
            ShowHealth = false;
			ShowOvertimeType = false;
            ShowOvertime = false;
			ShowSanctionType = false;
            ShowSanction = false;
        }
    }

}
