namespace Cliente.ApplicationStates
{
    public class DepartmentState
    {
        public Action? GeneralDepartmentAction { get; set; }
        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentClick()
        {
            ResetAllDepartments();
            ShowGeneralDepartment = true;
            GeneralDepartmentAction?.Invoke();
        }

        private void ResetAllDepartments()
        {
            ShowGeneralDepartment = false;
        }
    }

}
