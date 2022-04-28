using System.Collections.Generic;

class Stat
{
    public enum Type
    {
        MaxHP,
        MaxMP,
        MaxEnergyShield,
        PhysicalDamage,
        LightningDamage,
        ColdDamage,
        FireDamage,
        PoisonDamage,
        ArcaneDamage,
        HolyDamage,
        ChaosDamage,
        Armor,
        LightningResist,
        ColdResist,
        FireResist,
        PoisonResist,
        ArcaneResist,
        HolyResist,
        ChaosResist,
        HPRegen,
        MPRegen,
        EnergyShieldRegen,
        EnergyShieldRegenCooldown,
        DamageReduction,
        Evasion,
        WeaponBlock,
        WeaponBlockAmount,
        ShieldBlockChance,
        ShieldBlockAmount,
        CritChance,
        CritDamage,
    }

    public float baseValue;
    float totalValue;

    public bool isDirty;

    public List<StatModifier> modifiers;

    public float Value
    {
        get
        {
            if (isDirty)
            {
                totalValue = baseValue;
                float multA = 1;
                float multB = 1;
                float multC = 1;
                foreach (StatModifier modifier in modifiers)
                {
                    switch (modifier.type)
                    {
                        case StatModifier.Type.BaseFlat:
                        case StatModifier.Type.TotalFlat:
                            totalValue += modifier.value;
                            break;
                        case StatModifier.Type.BaseMult:
                            totalValue *= modifier.value;
                            break;
                        case StatModifier.Type.TotalMultA:
                            multA *= modifier.value;
                            break;
                        case StatModifier.Type.TotalMultB:
                            multB *= modifier.value;
                            break;
                        case StatModifier.Type.TotalMultC:
                            multC *= modifier.value;
                            break;
                    }
                }
                totalValue *= multA * multB * multC;
            }
            return totalValue;
        }
        set
        {
            baseValue = value;
        }
    }

    public Stat(float baseValue)
    {
        this.baseValue = baseValue;
        this.totalValue = baseValue;
    }

    public void AddModifier(StatModifier mod)
    {
        modifiers.Add(mod);
    }

    public void RemoveModifier(string name)
    {
        foreach(StatModifier mod in modifiers)
        {
            if(mod.name == name)
            {
                modifiers.Remove(mod);
            }
        }
    }

    public bool HasModifier(string name)
    {
        foreach(StatModifier mod in modifiers)
        {
            if(mod.name == name)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveModifiersBySource(object source)
    {
        foreach(StatModifier mod in modifiers)
        {
            if(mod.source == source)
            {
                modifiers.Remove(mod);
            }
        }
    }
}
