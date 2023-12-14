using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class MonoPosition : MonoBehaviour
{
    [SerializeField] private MainScene _mainscene;
    public ServicePosition ServicePosition;
    private Service _service;
    [SerializeField] private TableDisplay _tabledisplay;
    [SerializeField] private ManagerTable _managertable;
    private void Start()
    {
        _service = new Service();
        ServicePosition = new ServicePosition();
    }
    public void ToConsolePosition(IEnumerable<Position> positions)
    {
        _tabledisplay.ClearTable();
        foreach (var position in positions)
        {
            _tabledisplay.CreatePositionDisplay(position);
        }
    }
    public void OnGetPositionByPosition(string name)
    {
        var employees = ServicePosition.GetEmployeesNames(name);
        ToConsolePosition(employees);
    }
    public void OnGetPositions()
    {
        var positions = _service.GetAll<Position>();
        ToConsolePosition(positions);
    }
    public void AddPositionDateTable()
    {
        int nextpositionid = ServicePosition.GetNewID();
        Position newposition = new Position
        {
            ID_Position = nextpositionid,
            Position_Name = "Пусто",
            Description_Position = "Пусто",
            Basic_date = "Пусто"
        };
        _service.Add(newposition);
        OnGetPositions();
    }
}
