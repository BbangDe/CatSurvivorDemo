using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Shield : SkillBase
{
    private void OnEnable()
    {
        // 일정 시간 후 스킬이 사라지도록 세팅
        StartCoroutine(Disappear());
    }

    private void Update()
    {
        // 실드계열 스킬은 지속적으로 플레이어를 따라다니게 세팅
        transform.position = StageManager.instance.GetPlayerTransform().position + pivot;
    }
}
