namespace Cliente.ApplicationStates
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
		}
    }

}
