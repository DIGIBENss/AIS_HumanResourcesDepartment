
using System;
using TMPro;
using UnityEngine;

public class TableDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _contentprefab;
    public Transform contentPanel;
    private GameObject[] Table = new GameObject[99];
    [SerializeField] private MonoEmployee _monoEmployee;
    public void CreateDisplay(Employee employeeData, Position position)
    {
        GameObject newEmployee = Instantiate(_contentprefab[0], contentPanel);
        Table[employeeData.ID_Employee] = newEmployee;
        newEmployee.GetComponent<TaibleID>().GetEmployeeID(employeeData.ID_Employee);
        TextMeshProUGUI[] textFields = newEmployee.GetComponentsInChildren<TextMeshProUGUI>();
        textFields[0].text = employeeData.ID_Employee.ToString();
        textFields[1].text = employeeData.Surname;
        textFields[2].text = employeeData.Name;
        textFields[3].text = employeeData.Patronymic;
        textFields[4].text = position.Position_Name;
  
      
        textFields[5].text = position.Basic_date;
    }
    public void CreatePositionDisplay(Position positionData)
    {
        GameObject newPosition = Instantiate(_contentprefab[1], contentPanel);
        Table[positionData.ID_Position] = newPosition;
        newPosition.GetComponent<TaibleID>().GetPositionID(positionData.ID_Position);
        TextMeshProUGUI[] textFields = newPosition.GetComponentsInChildren<TextMeshProUGUI>();
        textFields[0].text = positionData.Position_Name;
        textFields[1].text = positionData.Description_Position;
        textFields[2].text = positionData.Basic_date;
    }
    public void CreateTrainingDisplay(Participation_In_Training participation, Training training)
    {
        GameObject newparticipation = Instantiate(_contentprefab[2], contentPanel);
        Table[participation.ID_Participation] = newparticipation;
        newparticipation.GetComponent<TaibleID>().GetParticionID(participation.ID_Participation);
        TextMeshProUGUI[] textFields = newparticipation.GetComponentsInChildren<TextMeshProUGUI>();
       var employeedate = _monoEmployee.ServiceEmployee.GetEmployeeID(participation.Employee_ID);
        textFields[0].text = participation.ID_Participation.ToString();
        textFields[1].text = employeedate.Surname;
        textFields[2].text = training.Organization;
        textFields[3].text = training.Cost.ToString();
        textFields[4].text = participation.Status_Participation;
    }
    public void CreateVacationDisplay(Employee employee, Vacation vacation)
    {
        GameObject newVacation = Instantiate(_contentprefab[3], contentPanel);
        Table[vacation.ID_Vacation] = newVacation;
        newVacation.GetComponent<TaibleID>().GetVacationID(vacation.ID_Vacation);
        TextMeshProUGUI[] textFields = newVacation.GetComponentsInChildren<TextMeshProUGUI>();
        textFields[0].text = vacation.ID_Vacation.ToString();
        textFields[1].text = employee.Surname;
        textFields[2].text = vacation.Start_date.ToString();
        textFields[3].text = vacation.End_date.ToString();
        textFields[4].text = vacation.Type_of_vacation;
    }
    public void ClearTable()
    {
       foreach(GameObject e in Table)
       {
         Destroy(e);
       }
    }
}