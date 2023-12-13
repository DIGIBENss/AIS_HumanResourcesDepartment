using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ManagerTable : MonoBehaviour
{
    [SerializeField] private GameObject[] _gnameline;
    [SerializeField] private TextMeshProUGUI _texttitle;
    [SerializeField] private GameObject _updatedb;
    [SerializeField] private GameObject _choiceposition;
    [SerializeField] private Transform _groupdata;
    [SerializeField] private Transform[] _updatetrasform;
    [Header("Связи")]
    [SerializeField] private MonoEmployee _employee;
    [SerializeField] private MonoPosition _position;
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
    private List<GameObject> _updatedchange = new List<GameObject>();
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
    public void CreateEmployeeDisplayID(Employee employeeData)
    {
        CreateEmployeeData();
        _currentEmployee = employeeData;
        _inputFields[0].text = employeeData.Surname;
        _inputFields[1].text = employeeData.Name;
        _inputFields[2].text = employeeData.Patronymic;
        _inputFields[3].text = employeeData.Data_of_birth;
        _inputFields[4].text = employeeData.Data_of_reception;
        _inputFields[5].text = employeeData.Phone_number;
        _inputFields[6].text = employeeData.Email;
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

        int result = _service.Update(_currentEmployee);
        _employee.OnGetDataTable();
        if (result > 0)
        {
            Debug.Log("Сотрудник успешно обновлен.");
        }
        else
        {
            Debug.Log("Ошибка обновления сотрудника.");
        }
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
    public void CreateEmployeeData()
    {
        DestroyUpdateData();
        for (int i = 0; i < employee.Length; i++)
        {
            GameObject newupdatedb = Instantiate(_updatedb, _groupdata);
            TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
            textFields.text = employee[i];
            _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
            _updatedchange.Add(newupdatedb);
        }
    }
    public void CreatePositionData()
    {
        DestroyUpdateData();
        for (int i = 0; i < position.Length; i++)
        {
            GameObject newupdatedb = Instantiate(_updatedb, _groupdata);
            TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
            textFields.text = position[i];
            _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
            _updatedchange[i] = newupdatedb;
        }
    }
    public void OnTable(int value)
    {
        switch(value)
        {
            case 0:
                _gnameline[0].SetActive(false);
                _gnameline[1].SetActive(true);
                _position.OnGetPositions();
                _texttitle.text = "Позиции";
                break;
            case 1:
                _gnameline[0].SetActive(true);
                _gnameline[1].SetActive(false);
                _employee.OnGetDataTable();
                _texttitle.text = "Сотрудники";
                break;
        }
    }
    public void DeleteTableRow(int id)
    {
        Debug.Log(id);
       var employees = _employee.ServiceEmployee.GetEmployeeID(id);
       var position = _position.ServicePosition.GetPositionID(employees.ID_Position);
        _service.Delete(employees);
        _service.Delete(position);
        _employee.OnGetDataTable();
    }
    public void AddEmployeeData(int positionid)
    {
        DestroyUpdateData();
        for (int i = 0; i < _addTextEmployee.Length; i++)
        {
            if(i != 7)
            {
                GameObject newupdatedb = Instantiate(_updatedb, _updatetrasform[i]);
                TextMeshProUGUI textFields = newupdatedb.GetComponentInChildren<TextMeshProUGUI>();
                textFields.text = _addTextEmployee[i];
                _inputFields[i] = newupdatedb.GetComponentInChildren<TMP_InputField>();
                _updatedchange.Add(newupdatedb);
            }
            else if(i == 7)
            {
                GameObject newchoiceposition = Instantiate(_choiceposition, _updatetrasform[i]);
                TMP_Dropdown dropdown = newchoiceposition.GetComponent<TMP_Dropdown>();
                dropdown.GetComponent<Choice_Position>().GetPositionID(positionid);
                OnGetDropdown(dropdown, positionid);
            }
           
        }
    }
    public void AddEmployeeDisplayID(Employee employeeData, int positionid)
    {
        AddEmployeeData(positionid);
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
        _service.Update(_currentEmployee);
        _employee.OnGetDataTable();
    }
    public void NotNullCategory(int id, int value)
    {
        var employee = _employee.ServiceEmployee.GetEmployeeID(id);
        employee.ID_Position = value;
        _service.Update(employee);
        _employee.OnGetDataTable();
    }
    public void OnGetDropdown(TMP_Dropdown dropdown, int active)
    {
        dropdown.ClearOptions();
        active--;
        var positions = _service.GetAll<Position>();
        List<string> shelfLifeCategories = new List<string>();
        foreach (var position in positions)
        {
            shelfLifeCategories.Add(position.Position_Name);
        }
        dropdown.AddOptions(shelfLifeCategories);
        dropdown.value = active;
    }
}
