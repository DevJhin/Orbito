﻿using UnityEngine;
using System.Collections.Generic;
public enum EquipmentType
{
    /// <summary>
    /// 공격 조작을 통해 사용할 수 있는 무기 장비 타입.
    /// </summary>
    Weapon,

    /// <summary>
    /// 별도로 사용하지 않아도 능력치를 올려주는 무기 외 장비 타입.
    /// </summary>
    NonWeapon
}

public class Equipment
{
    /// <summary>
    /// 장비의 이름, 또는 ID.
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// 장비의 타입.
    /// </summary>
    public readonly EquipmentType EquipmentType;

    /// <summary>
    /// 장비의 BattleAction. 기본적으로 Weapon 타입 장비에서 사용됨.
    /// </summary>
    public ITriggerBattleAction BattleAction
    {
        get;
        private set;
    }

    public Stats Stats;

    public Equipment(string name, EquipmentType equipmentType, ITriggerBattleAction battleAction, Stats stats)
    {
        this.Name = name;
        this.EquipmentType = equipmentType;

        this.BattleAction = battleAction;
        this.Stats = stats;
    }

    /// <summary>
    /// 장비 객체를 생성하는 정적 팩토리 메소드.
    /// </summary>
    /// <param name="battleAction">장비에서 사용되는 BattleAction.</param>
    /// <returns></returns>
    public static Equipment CreateEquipment(string name, EquipmentType equipmentType, ITriggerBattleAction battleAction, Stats stats)
    {
        return new Equipment(name, equipmentType, battleAction, stats);
    }
}
