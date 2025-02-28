using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    // 레벨에 따른 스킬 데이터(서버에서 받도록 되어 있으나 데모에서는 프로젝트에 삽입)
    [SerializeField]
    List<int> coolDown;

    [SerializeField]
    List<int> damage;

    [SerializeField]
    List<int> count;

    [SerializeField]
    List<float> term;

    [SerializeField]
    List<int> speed;

    [SerializeField]
    List<int> lifeTime;

    [SerializeField]
    SkillBase skill;

    int skillLevel;

    // 스킬 데이터 리턴해주는 함수들
    public int GetCoolDown()
    {
        return coolDown[skillLevel];
    }

    public int GetDamage()
    {
        return damage[skillLevel];
    }

    public int GetCount()
    {
        return count[skillLevel];
    }

    public float GetTerm()
    {
        return term[skillLevel];
    }

    public int GetSpeed()
    {
        return speed[skillLevel];
    }

    public SkillBase GetSkillBase()
    {
        return skill;
    }

    public int GetSkillLevel()
    {
        return skillLevel;
    }

    public int GetLifeTime()
    {
        return lifeTime[skillLevel];
    }
}
