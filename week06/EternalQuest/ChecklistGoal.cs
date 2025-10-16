public class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountComplete = 0;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public void SetAmountComplete (int amountComplete)
    {
        _amountComplete = amountComplete;
    }
    public override void RecordEvent()
    {
        _amountComplete++;
    }

    public override bool IsComplete()
    {
        if (_amountComplete >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[x] {GetName()} ({GetDescription()}) -- Currently completed: {_amountComplete}/{_target}";
        }
        else
        {
            return $"[ ] {GetName()} ({GetDescription()}) -- Currently completed: {_amountComplete}/{_target}";
        }
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_amountComplete}|{_target}|{_bonus}";
    }
}