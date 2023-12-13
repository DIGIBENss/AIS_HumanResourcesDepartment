using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TaibleID : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] private ManagerTable _managerTable;
    private ServiceEmployee _serviceemployee;
    private ServicePosition _serviceposition;
    public int ID_Employee;
    public int ID_Position;
    private void Start()
    {
       _serviceemployee = new ServiceEmployee();
        _serviceposition = new ServicePosition();
        _managerTable = FindObjectOfType<ManagerTable>();;
    }
    public void GetEmployeeID(int id) => ID_Employee = id;
    public void GetPositionID(int id) => ID_Position = id;

  
    public void OpenChangeEmployee()
    {
        var employee = _serviceemployee.GetEmployeeID(ID_Employee);
        if (employee != null)
        {
            _managerTable.CreateEmployeeDisplayID(employee);
        }
        else
        {
            Debug.Log("Сотрудник с ID " + ID_Employee + " не найден.");
        }
    }
    public void OpenChangePosition()
    {
        var position = _serviceposition.GetPositionID(ID_Position);
        if (position != null)
        {
            _managerTable.CreatePositionDisplayID(position);
        }
        else
        {
            Debug.Log("Сотрудник с ID " + ID_Position + " не найден.");
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
        _managerTable.DeleteTableRow(ID_Employee);
        Destroy(gameObject);
    }


}
