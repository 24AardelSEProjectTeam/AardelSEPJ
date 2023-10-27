using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LilyAttack : MonoBehaviour
{
    //public float attackDamage = 17f;
    //public GameObject projectilePrefab; // �߻�ü ������
    //private Unit unitScript;


    //private void Start()
    //{


    //    unitScript = GetComponent<Unit>();

    //    // Add the following debug lines
    //    if (unitScript == null)
    //    {
    //        Debug.LogError("Unit script is not attached!");
    //    }
    //    else
    //    {
    //        Debug.Log("Unit script is attached. UnitType: " + unitScript.unitType);
    //    }
    //}

    //private void Update()
    //{
    //    GameObject target = FindClosestMonster();

    //    if (target)
    //    {
    //        Attack(target);

    //    }
    //}

    //GameObject FindClosestMonster()
    //{
    //    // This will find the closest monster based on distance within the attack range. 
    //    GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
    //    GameObject closest = null;
    //    float distance = Mathf.Infinity;

    //    foreach (GameObject monster in monsters)
    //    {
    //        float curDistance = Vector2.Distance(transform.position, monster.transform.position);
    //        if (curDistance < distance /*&& curDistance <= attackRange*/)
    //        {
    //            closest = monster;
    //            distance = curDistance;
    //        }
    //    }
    //    return closest;
    //}


    //private void Attack(GameObject target)
    //{

    //    GameObject Lilyprojectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
    //    LilyProjectile projectileScript = Lilyprojectile.GetComponent<LilyProjectile>();

    //    projectileScript.originatingUnitTransform = this.transform;

    //    projectileScript.target = target;
    //    projectileScript.damage = attackDamage;

    //    if (unitScript && unitScript.unitType == 2)  // Checking if it's Lily
    //    {
    //        if (unitScript.unitLevel == 1)
    //        {
    //            projectileScript.poisonDamagePercentage = 0.05f;
    //            projectileScript.damageInterval = 0.2f;
    //        }
    //        else if (unitScript.unitLevel == 3)
    //        {
    //            projectileScript.poisonDamagePercentage = 0.10f;
    //            projectileScript.damageInterval = 0.2f;
    //        }
    //        else if (unitScript.unitLevel == 5)
    //        {
    //            projectileScript.poisonDamagePercentage = 0.10f;
    //            projectileScript.damageInterval = 0.15f;
    //        }
    //    }
    //}
    public GameObject laserPrefab;
    private GameObject currentLaser;
    private Unit unitScript;
    public float damage = 17f;
    public float damageInterval = 0.2f;
    public float poisonDamagePercentage = 0.05f;
    private MonsterController currentTarget;
    private GameObject target;
    IEnumerator dotDamageCoroutine;
    private void Start()
    {
        unitScript = GetComponent<Unit>();
    }
    void Update()
    {

        target = FindClosestMonster();

       if(target != null )
        {
            StartLaserAttack();
            
        }

       if(target == null)
        {
            Destroy(currentLaser);
        }    
    }

    GameObject FindClosestMonster()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject closest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject monster in monsters)
        {
            float curDistance = Vector2.Distance(transform.position, monster.transform.position);
            if (curDistance < distance /*&& curDistance <= attackRange*/)
            {
                closest = monster;
                distance = curDistance;
            }
        }
        return closest;
    }
    IEnumerator DealDotDamage(IDamageable damageableEntity)
    {
        while (damageableEntity != null) // ����� �����ϰ� ü���� 0 �̻��� ���
        {
            yield return new WaitForSeconds(damageInterval);
            float dotDamage = damage * poisonDamagePercentage;
            damageableEntity.TakeDamage(dotDamage);
        }

        StopLaserAttack();
    }
    void StartLaserAttack()
    {
        if (unitScript && unitScript.unitType == 2)  // Checking if it's Lily
        {
            if (unitScript.unitLevel == 1)
            {
                poisonDamagePercentage = 0.05f;
                damageInterval = 0.2f;
            }
            else if (unitScript.unitLevel == 3)
            {
                poisonDamagePercentage = 0.10f;
                damageInterval = 0.2f;
            }
            else if (unitScript.unitLevel == 5)
            {
                poisonDamagePercentage = 0.10f;
                damageInterval = 0.15f;
            }
        }
        //}
        if (currentLaser == null)
        {
            currentLaser = Instantiate(laserPrefab, transform.position, Quaternion.identity, transform);
        }

        // ���������� ���͸� ���ϵ��� ����
        currentLaser.transform.up = target.transform.position - transform.position;

        // �������� ���̸� ���ְ� ���� ������ �Ÿ��� ����
        float laserLength = Vector2.Distance(transform.position, target.transform.position);
        currentLaser.transform.localScale = new Vector2(1, laserLength / 4.5f);

        // target�� IDamageable�� ��ȯ�Ͽ� ���
        IDamageable damageableEntity = target.GetComponent<IDamageable>();
        if (damageableEntity != null)
        {
            // �̹� ���� ���� ������ �ڷ�ƾ�� ����
            if (dotDamageCoroutine != null)
            {
                StopCoroutine(dotDamageCoroutine);
            }

            // ���ο� ������ �ڷ�ƾ ����
            dotDamageCoroutine = DealDotDamage(damageableEntity);
            StartCoroutine(dotDamageCoroutine);
        }
    }



    void StopLaserAttack()
    {
        if (currentLaser != null)
        {
            Destroy(currentLaser);
        }
    }
}

