class StatModifier
{
    public enum Type
    {
        BaseFlat,
        BaseMult,
        TotalFlat,
        TotalMultA,
        TotalMultB,
        TotalMultC,
    }

    public readonly float value;
    public readonly string name;
    public readonly Type type;
    public readonly object source;

    public StatModifier(float value, string name, Type type, object source)
    {
        this.value = value;
        this.name = name;
        this.type = type;
        this.source = source;
    }
}
