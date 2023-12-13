
using TMPro;
using UnityEngine;

public class TableDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _contentprefab;
    public Transform contentPanel;
    [SerializeField]private GameObject[] Table = new GameObject[99];
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
        for (int i = 0; i < employeeData.ID_Position; i++)
        {
            if (employeeData.ID_Position == position.ID_Position)
            {
                textFields[4].text = position.Position_Name;
            }
        }
        textFields[5].text = position.Basic_date;

    }
    public void ClearTable()
    {
       foreach(GameObject e in Table)
       {
           Destroy(e);
       }
    }
}