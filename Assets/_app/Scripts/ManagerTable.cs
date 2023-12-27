using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerTable : MonoBehaviour
{
    [SerializeField] private GameObject[] _gnameline;
    [SerializeField] private TextMeshProUGUI _texttitle;
    [SerializeField] private Transform _groupdata;
    [SerializeField] private Transform[] _updatetrasform;
    [Header("Префабы")]
    [SerializeField] private GameObject _update_employee;
    [SerializeField] private GameObject _updateposition;
    [SerializeField] private GameObject _updat_training;
    [SerializeField] private GameObject _update_vacation;
    [SerializeField] private GameObject _addemploye_eprefab;
    [SerializeField] private GameObject _choice_employee;
    [SerializeField] private GameObject _choiceposition;
    [SerializeField] private GameObject _choicevacation;
    [Header("Связи")]
    [SerializeField] private MonoEmployee _employee;
    [SerializeField] private MonoPosition _position;
    [SerializeField] private MonoTraining _training;
    [SerializeField] private MonoVacation _vacation;
    [Header("Таблицы")]
    [SerializeField] private string[] employee;
    [SerializeField] private string[] position;
    [SerializeField] private string[] Training;
    [SerializeField] private string[] Vacation;
    [SerializeField] private string[] ParticipationInTraining;
    [SerializeField] private string[] _addTextEmployee;
    [Header("Изменение")]
    [SerializeField] private TMP_InputField[] _inputFields;
    private Service _service;
    private Employee _currentEmployee;
    private Position _currentPosition;
    private Training _currentTraining;
    private Vacation _currentVacation;
    private Participation_In_Training _currentParticipation;
    private List<GameObject> _updatedchange = new List<GameObject>();
    [Header("Кнопки")]
    [SerializeField] private GameObject _bttposition;
    [SerializeField] private GameObject _btttraining;
    [SerializeField] private GameObject _bttvacation;
    private int _indexwork;
    private void Start()
    {
        _service = new Service();
    }
    public void DestroyUpdateData()
    {
        foreach (GameObject item in _updatedchange)
        {
            Destroy(item);
        }
        _updatedchange.Clear();
    }
        
    //                                           Employee
    public void CreateEmployeeDisplayID(Employee employeeData, Position positionData)
    {
        CreateEmployeeData(positionData, employeeData);
        _currentEmployee = employeeData;
        _inputFields[0].text = employeeData.Surname;
        _inputFields[1].text = employeeData.Name;
        _inputFields[2].text = employeeData.Patronymic;
        _inputFields[3].text = employeeData.Data_of_birth;
        _inputFields[4].text = employeeData.Data_of_reception;
        _inputFields[5].text = employeeData.Phone_number;
        _inputFields[6].text = employeeData.Email;
    }
    public void CreateEmployeeData(Position position, Employee employeeData)
    {
        DestroyUpdateData();
        for (int i = 0; i < employee.Length; i++)
        {
            if(i != 7)
            {
                GameObject newupdatedb = Instantiate(_update_employee, _groupdata);
                TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
                textFields.text = employee[i];
                _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
                _updatedchange.Add(newupdatedb);
            }
            else if(i == 7)
            {
              GameObject newchoiceposition = Instantiate(_choiceposition, _updatetrasform[8]);
              TMP_Dropdown dropdown = newchoiceposition.GetComponent<TMP_Dropdown>();
              dropdown.GetComponent<Choice_Position>().GetEmployeeID(employeeData.ID_Employee);
              OnGetDropdownPosition(dropdown, position.ID_Position);
                _updatedchange.Add(newchoiceposition);
            }
        }
    }
    public void UpdateEmployee()
    {
        _currentEmployee.Surname = _inputFields[0].text;
        _currentEmployee.Name = _inputFields[1].text;
        _currentEmployee.Patronymic = _inputFields[2].text;
        _currentEmployee.Data_of_birth = _inputFields[3].text;
        _currentEmployee.Data_of_reception = _inputFields[4].text;
        _currentEmployee.Phone_number = _inputFields[5].text;
        _currentEmployee.Email = _inputFields[6].text;
         _service.Update(_currentEmployee);
        _employee.OnGetDataTable();
    }
    public void AddEmployeeData(int employeeid)
    {
        DestroyUpdateData();
        for (int i = 0; i < _addTextEmployee.Length; i++)
        {
            if (i != 7)
            {
                GameObject newupdatedb = Instantiate(_addemploye_eprefab, _updatetrasform[i]);
                TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
                textFields.text = _addTextEmployee[i];
                _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
                _updatedchange.Add(newupdatedb);
            }
            else if (i == 7)
            {
                GameObject newchoiceposition = Instantiate(_choiceposition, _updatetrasform[i]);
                TMP_Dropdown dropdown = newchoiceposition.GetComponent<TMP_Dropdown>();
                dropdown.GetComponent<Choice_Position>().GetEmployeeID(employeeid);
                OnGetDropdownPosition(dropdown, 1);
            }

        }
    }
    public void AddEmployeeDisplayID(Employee employeeData, int employeeid)
    {
        AddEmployeeData(employeeid);
        _currentEmployee = employeeData;
        _inputFields[0].text = employeeData.Surname;
        _inputFields[1].text = employeeData.Name;
        _inputFields[2].text = employeeData.Patronymic;
        _inputFields[3].text = employeeData.Data_of_birth;
        _inputFields[4].text = employeeData.Data_of_reception;
        _inputFields[5].text = employeeData.Phone_number;
        _inputFields[6].text = employeeData.Email;
    }
    public void UpdateEmployeeDisplayID()
    {
        _currentEmployee.Surname = _inputFields[0].text;
        _currentEmployee.Name = _inputFields[1].text;
        _currentEmployee.Patronymic = _inputFields[2].text;
        _currentEmployee.Data_of_birth = _inputFields[3].text;
        _currentEmployee.Data_of_reception = _inputFields[4].text;
        _currentEmployee.Phone_number = _inputFields[5].text;
        _currentEmployee.Email = _inputFields[6].text;
        _currentEmployee.Position_ID = _indexwork;
        _service.Update(_currentEmployee);
        _employee.OnGetDataTable();
    }
    //                       Position
    public void CreatePositionDisplayID(Position positiondata)
    {
        CreatePositionData();
        _currentPosition = positiondata;
        _inputFields[0].text = positiondata.Position_Name;
        _inputFields[1].text = positiondata.Description_Position;
        _inputFields[2].text = positiondata.Basic_date;
    }
    public void UpdatePosition()
    {
       _currentPosition.Position_Name = _inputFields[0].text;
       _currentPosition.Description_Position = _inputFields[1].text;
       _currentPosition.Basic_date = _inputFields[2].text;
       _service.Update(_currentPosition);
        _position.OnGetPositions();
    }
    public void CreatePositionData()
    {
        DestroyUpdateData();
        for (int i = 0; i < position.Length; i++)
        {
            GameObject newupdatedb = Instantiate(_updateposition, _groupdata);
            TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
            textFields.text = position[i];
            _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
            _updatedchange.Add(newupdatedb);
        }
    }
    public void OnGetDropdownPosition(TMP_Dropdown dropdown, int active)
    {
        --active;
        dropdown.ClearOptions();
        var positions = _service.GetAll<Position>();
        List<string> shelfLifeCategories = new List<string>();
        foreach (var position in positions)
        {
            shelfLifeCategories.Add(position.Position_Name);
        }
        dropdown.AddOptions(shelfLifeCategories);
        dropdown.value = active;
    }
    //                       Training
    public void CreateTrainingData(Participation_In_Training training)
    {
        DestroyUpdateData();
        for (int i = 0; i < ParticipationInTraining.Length; i++)
        {
            if(i != 0)
            {
                GameObject newupdatedb = Instantiate(_updat_training, _groupdata);
                TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
                textFields.text = ParticipationInTraining[i];
                _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
                _updatedchange.Add(newupdatedb);
            }
            else if(i == 0)
            {
                GameObject newchoiceposition = Instantiate(_choice_employee, _updatetrasform[8]);
                TMP_Dropdown dropdown = newchoiceposition.GetComponent<TMP_Dropdown>();
                dropdown.GetComponent<Choice_Employee>().GetParticipationID(training.ID_Participation);
                OnGetDropdownEmployee(dropdown, training.Employee_ID);
                _updatedchange.Add(newchoiceposition);
            }

        }
    }
    public void CreateTrainingDisplayID(Participation_In_Training participationdata, Employee employee, Training training)
    {
        CreateTrainingData(participationdata);
        _currentParticipation = participationdata;
        _currentEmployee = employee;
        _currentTraining = training;

        _inputFields[1].text = _currentTraining.Organization;
        _inputFields[2].text = _currentTraining.Course_Name;
        _inputFields[3].text = _currentTraining.Cost.ToString();
        _inputFields[4].text = _currentTraining.Start_Data.ToString();
        _inputFields[5].text = _currentTraining.End_Data.ToString();
        _inputFields[6].text = _currentParticipation.Status_Participation;
        _inputFields[7].text = _currentParticipation.Evaluation.ToString();
        _inputFields[8].text = _currentParticipation.Feedback;
    }
    public void UpdateParticipation()
    {
        _currentTraining.Organization = _inputFields[1].text;
        _currentTraining.Course_Name = _inputFields[2].text;
        _currentTraining.Cost = int.Parse(_inputFields[3].text); 
        _currentTraining.Start_Data = DateTime.Parse(_inputFields[4].text); 
        _currentTraining.End_Data = DateTime.Parse(_inputFields[5].text);
        _currentParticipation.Status_Participation = _inputFields[6].text;
        _currentParticipation.Evaluation = float.Parse(_inputFields[7].text);
        _currentParticipation.Feedback = _inputFields[8].text;
        _service.Update(_currentParticipation);
        _service.Update(_currentTraining);
        _training.OnGetDataTraining();
    }
    public void OnGetDropdownEmployee(TMP_Dropdown dropdown, int active)
    {
        dropdown.ClearOptions();
        var positions = _service.GetAll<Employee>();
        List<string> shelfLifeCategories = new List<string>();
        foreach (var position in positions)
        {
            shelfLifeCategories.Add(position.Surname);
        }
        dropdown.AddOptions(shelfLifeCategories);
        dropdown.value = active;
    }
    //                       Vacation
    public void CreateVacationData(Vacation vacation)
    {
        DestroyUpdateData();
        for (int i = 0; i < Vacation.Length; i++)
        {
            if (i != 0)
            {
                GameObject newupdatedb = Instantiate(_update_vacation, _groupdata);
                TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
                textFields.text = Vacation[i];
                _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
                _updatedchange.Add(newupdatedb);
            }
            else if (i == 0)
            {
                GameObject newchoicevacation = Instantiate(_choicevacation, _updatetrasform[8]);
                TMP_Dropdown dropdown = newchoicevacation.GetComponent<TMP_Dropdown>();
                dropdown.GetComponent<Choice_Vacation>().GetVacationID(vacation.ID_Vacation);
                OnGetDropdownEmployee(dropdown, vacation.Employee_ID);
                _updatedchange.Add(newchoicevacation);
            }

        }
    }
    public void CreateVacationDisplayID(Vacation vacation, Employee employee)
    {
        CreateVacationData(vacation);
        _currentVacation = vacation;
        _currentEmployee = employee;

        _inputFields[1].text = _currentVacation.Start_date.ToString();
        _inputFields[2].text = _currentVacation.End_date.ToString();
        _inputFields[3].text = _currentVacation.Type_of_vacation;
    }
    public void UpdateVacation()
    {
        _currentVacation.Start_date  = _inputFields[1].text;
        _currentVacation.End_date = _inputFields[2].text;
        _currentVacation.Type_of_vacation = _inputFields[3].text;
        _service.Update(_currentVacation);
        _service.Update(_currentEmployee);
        _vacation.OnGetDataVacation();
    }

    public void OnTable(int value)
    {
        _gnameline[0].SetActive(value == 1);
        _gnameline[1].SetActive(value == 0);
        _gnameline[2].SetActive(value == 2);
        _gnameline[3].SetActive(value == 3);

        _bttposition.SetActive(value == 0);
        _btttraining.SetActive(value == 2);
        _bttvacation.SetActive(value == 3);


        switch (value)
        {
            case 0:
                _texttitle.text = "Позиции";
                _position.OnGetPositions();
                break;
            case 1:
                _texttitle.text = "Сотрудники";
                _employee.OnGetDataTable();
                break;
            case 2:
                _texttitle.text = "Обучение";
                _training.OnGetDataTraining();
                break;
            case 3:
                _texttitle.text = "Отпуск";
                _vacation.OnGetDataVacation();
                break;
        }
    }
    public void DeleteTableRowEmployee(int id)
    {
       var employees = _employee.ServiceEmployee.GetEmployeeID(id);
        _service.Delete(employees);
        _employee.OnGetDataTable();
    }
    public void DeleteTableRowPosition(int id)
    {
        var position = _position.ServicePosition.GetPositionID(id);
        _service.Delete(position);
        _position.OnGetPositions();
    }
    public void DeleteTableRowPartication(int id)
    {
        var partication = _training.ServiceParticipation.GetParticipationID(id);
        _service.Delete(partication);
        _training.OnGetDataTraining();
    }
    public void NotNullCategory(int id, int value)
    {
        _indexwork = value;
        var employee = _employee.ServiceEmployee.GetEmployeeID(id);
        employee.Position_ID = _indexwork;
        _service.Update(employee);
        _employee.OnGetDataTable();
    }
    public void NotNullSurname(int id, int value)
    {
        _indexwork = value;
        var participation = _training.ServiceParticipation.GetParticipationID(id);
        participation.Employee_ID = _indexwork;
        _service.Update(participation);
        _training.OnGetDataTraining();
    }
    public void NotNullVacation(int id, int value)
    {
        _indexwork = value;
        var vacation = _vacation.ServiceVacation.GetVacationID(id);
        vacation.Employee_ID = _indexwork;
        _service.Update(vacation);
        _vacation.OnGetDataVacation();
    }
}
