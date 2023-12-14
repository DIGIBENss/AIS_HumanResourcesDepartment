using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaibleID : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] private ManagerTable _managerTable;
    private ServiceEmployee _serviceemployee;
    private ServicePosition _serviceposition;
    private ServiceParticipation _serviceParticipation;
    private ServiceTraining _serviceTraining;
    [SerializeField] private int _id_employee;
    [SerializeField] private int _id_position;
    public int ID_Particion;
    public int ID_Vacation;
    private void Start()
    {
       _serviceemployee = new ServiceEmployee();
        _serviceposition = new ServicePosition();
        _serviceParticipation = new ServiceParticipation();
        _serviceTraining = new ServiceTraining();
        _managerTable = FindObjectOfType<ManagerTable>();;
    }
    public void GetEmployeeID(int id) => _id_employee = id;
    public void GetPositionID(int id) => _id_position = id;
    public void GetParticionID(int id) => ID_Particion = id;
    public void GetVacationID(int id) => ID_Vacation = id;


    public void OpenChangeEmployee()
    {
        var employee = _serviceemployee.GetEmployeeID(_id_employee);
        if (employee != null)
        {
            var position = _serviceposition.GetPositionID(employee.Position_ID);
            _managerTable.CreateEmployeeDisplayID(employee, position);
        }
        else
        {
            Debug.Log("Сотрудник с ID " + _id_employee + " не найден.");
        }
    }
    public void OpenChangePosition()
    {
        var position = _serviceposition.GetPositionID(_id_position);
        if (position != null)
        {
            _managerTable.CreatePositionDisplayID(position);
        }
        else
        {
            Debug.Log("Сотрудник с ID " + _id_position + " не найден.");
        }
    }
    public void OpenChangeTraining()
    {
        var participation = _serviceParticipation.GetParticipationID(ID_Particion);
        if (participation != null)
        {
            var employee = _serviceemployee.GetEmployeeID(participation.Employee_ID);
            var training = _serviceTraining.GetTrainingID(participation.Trainig_ID);
            _managerTable.CreateTrainingDisplayID(participation, employee, training);
        }
        else
        {
            Debug.Log("Сотрудник с ID " + _id_position + " не найден.");
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DeleteObject();
        }
    }
    private void DeleteObject()
    {
        if(_id_employee != 0)
        {
            _managerTable.DeleteTableRowEmployee(_id_employee);
            Destroy(gameObject);
        }
        if(_id_position != 0)
        {
            _managerTable.DeleteTableRowPosition(_id_position);
            Destroy(gameObject);
        }
        if (ID_Particion != 0)
        {
            _managerTable.DeleteTableRowPosition(_id_position);
            Destroy(gameObject);
        }

    }


}
