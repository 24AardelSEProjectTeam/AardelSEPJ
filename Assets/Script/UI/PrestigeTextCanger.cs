using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeTextCanger : MonoBehaviour
{
    public Text prestigeText;
    // Start is called before the first frame update
    void Start()
    {
        TextUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TextUpdate()
    {
        if (GameManager.Instance.unitEvolutionData[0].isPrestige == true)
        {
            prestigeText.text = "Į���� ���ݼӵ� 50% ����";
        }
        else if (GameManager.Instance.unitEvolutionData[1].isPrestige == true)
        {
            prestigeText.text = "���� �нú�: ���̺� �� 10�ʸ��� <������> ȿ���� �� ��ü 100%Ȯ���� 1�ʰ� ���";
        }
        else if (GameManager.Instance.unitEvolutionData[2].isPrestige == true)
        {
            prestigeText.text = "�ܵ� �нú�: ������ ���� �� 1�ʸ��� ��Ʈ ������ 1%�� ����(�ִ� 10%)";
        }
        else if (GameManager.Instance.unitEvolutionData[3].isPrestige == true)
        {
            prestigeText.text = "�ܵ� �нú�: 0�ܰ� ���̸� ���ֵ� <�ູ> ��ų�� ȿ���� ����";
        }
        else if (GameManager.Instance.unitEvolutionData[4].isPrestige == true)
        {
            prestigeText.text = "�ܵ� �нú�: ������ Ȯ���� 50%�� �����Ѵ�. (20%����)";
        }
        else if (GameManager.Instance.unitEvolutionData[5].isPrestige == true)
        {
            prestigeText.text = "�ܵ� �нú�: ���� �ܰ谡 ���� ���� ���� 1���� ���ݷ� 10% ����";
        };

    }
}
