using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    // ������ ���� ��ų ������(�������� �޵��� �Ǿ� ������ ���𿡼��� ������Ʈ�� ����)
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

    // ��ų ������ �������ִ� �Լ���
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
