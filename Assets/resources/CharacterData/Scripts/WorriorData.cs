using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "Worrior Data", menuName = "characterData/Worrior")]
public class WorriorData : CharacterData
{
    public worriorClassType worriorClassType;
    public worriorWeaponType worriorWeaponType;
}
