using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyProjectile : MonoBehaviour
{


    public float poisonDamagePercentage = 0.05f; // ��Ʈ �������� �����
    public float damageInterval = 0.2f; // ������ ����
    private bool isDealingDamage = false; // ������ ���� ������ Ȯ���ϴ� �÷���
    public float damage = 17f;
    public float laserDuration = 0.5f;
    public GameObject target;
    private Vector3 directionToTarget;
    private bool laserCreated = false;  // �������� �̹� �����Ǿ����� Ȯ���ϴ� ����
    public Transform originatingUnitTransform;
    LilyAttack lilyAttack;
    private void Start()
    {
        //lilyAttack = GetComponent<LilyAttack>();
    }
    private void Update()
    {

        //transform.localScale += new Vector3(0.25f, scalingSpeed, 0);
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Monster");
            Destroy(this.gameObject);

        }
        else   // �������� ���� �������� �ʾ�����
        {
            CreateLaser();
        }
        //if (target && originatingUnitTransform)
        //{
        //    directionToTarget = (target.transform.position - originatingUnitTransform.position).normalized;
        //    float distanceToTarget = Vector3.Distance(originatingUnitTransform.position, target.transform.position);

        //    // ������ ������ ���� ����
        //    transform.localScale = new Vector3(0.25f, Mathf.Min(transform.localScale.y + scalingSpeed, distanceToTarget / 10), 0.25f);

        //    // �������� ���� ��ġ ���� ����
        //    transform.position = originatingUnitTransform.position;
        //}

        //if (Vector2.Distance(transform.position, target.transform.position) <= 0.1f)
        //{
        //    HitTarget();
        //}
    }

    void CreateLaser()
    {
        

        directionToTarget = (target.transform.position - transform.position);
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        //������ ������ ����
        transform.localScale = new Vector3(0.25f, distanceToTarget / 10, 0.25f);

        //�������� ���� ��ġ�� �������� �ʵ��� ������ ����
        //transform.position = transform.position + directionToTarget * (distanceToTarget / 2);
        transform.position = originatingUnitTransform.position;

        // ������ ȸ�� ����
        transform.rotation = Quaternion.FromToRotation(Vector3.up, directionToTarget);

        

        //HitTarget();
    }

    //private IEnumerator DestroyLaserAfterTime(float duration)
    //{
    //    yield return new WaitForSeconds(duration);
    //    Destroy(gameObject);
    //    laserCreated=false;
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("LilyProjectile collided with: " + other.gameObject.name);
        //MonsterController monster = other.GetComponent<MonsterController>();
        //if (monster != null && !isDealingDamage)
        //{
        //    StartCoroutine(DealDotDamage(monster));  // ��Ʈ ������ ���� ����
        //}

        Debug.Log("LilyProjectile collided with: " + other.gameObject.name);
        IDamageable damageableEntity = other.GetComponent<IDamageable>();
        if (damageableEntity != null && !isDealingDamage)
        {
            StartCoroutine(DealDotDamage(damageableEntity));  // DOT ������ ó�� ����
        }
    }

    //void HitTarget()
    //{
    //    MonsterController monsterScript = target.GetComponent<MonsterController>();
    //    monsterScript.TakeDamage(damage);
    //    Debug.Log("hit");
    //    /*Destroy(gameObject); */ // Destroy the projectile after hitting the target

    //}

    private IEnumerator DealDotDamage(IDamageable damageableEntity)
    {
       

        isDealingDamage = true;
        while (damageableEntity != null) // ����� �����ϰ� ü���� 0 �̻��� ���
        {
            yield return new WaitForSeconds(damageInterval);
            float dotDamage = damage * poisonDamagePercentage;
            damageableEntity.TakeDamage(dotDamage);
        }
        isDealingDamage = false;
        //Destroy(gameObject);

    }
}
