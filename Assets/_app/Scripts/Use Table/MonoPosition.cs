using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoPosition : MonoBehaviour
{
    [SerializeField] private MainScene _mainscene;
    public ServicePosition ServicePosition;
    private Service _service;
    [SerializeField] private TableDisplay _tabledisplay;
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
}
