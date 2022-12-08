using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test : MonoBehaviour
{
    public int countE,countF,countG,countC;
    public void OnClick()
    {

        GameObject Gold = GameObject.Find("Gold");
        GameObject C = GameObject.Find("C");
        GameObject E = GameObject.Find("E");
        GameObject F = GameObject.Find("F");
        GameObject G = GameObject.Find("G");
        GameObject Out = GameObject.Find("Out");
        int totalGold = int.Parse(Gold.GetComponent<InputField>().text);
        int c = int.Parse(C.GetComponent<InputField>().text);
        int e = int.Parse(E.GetComponent<InputField>().text);
        int f = int.Parse(F.GetComponent<InputField>().text);
        int g = int.Parse(G.GetComponent<InputField>().text);
        countC = c;
        countE = e;
        countF = f;
        countG = g;
        Exam exam = new Exam();
        Exam.MaterialData itemC = ItemDataC();
        Exam.MaterialData itemE = ItemDataE();
        Exam.MaterialData itemF = ItemDataF();
        Exam.MaterialData itemG = ItemDataG();
        Exam.ItemData itemA = ItemDataA();
        Out.GetComponent<InputField>().text = exam.Run(itemA, totalGold).ToString();
    }
    Exam.ItemData ItemDataA()
    {
        Exam.ItemData item = new Exam.ItemData();
        item.id = 1;
        item.count = 0;
        item.costGold = 26;
        item.materialList = new List<Exam.MaterialData>();
        item.materialList.Add(ItemDataB());
        item.materialList.Add(ItemDataC());
        item.materialList.Add(ItemDataD());
        return item;
    }
    Exam.MaterialData ItemDataB()
    {
        Exam.MaterialData material = new Exam.MaterialData();
        material.count = 3;
        Exam.ItemData item = new Exam.ItemData();
        item.id = 2;
        item.count = 0;
        item.costGold = 53;
        item.materialList = new List<Exam.MaterialData>();
        item.materialList.Add(ItemDataE());
        item.materialList.Add(ItemDataF());
        material.item = item;
        return material;
    }
    Exam.MaterialData ItemDataC()
    {
        Exam.MaterialData material = new Exam.MaterialData();
        material.count = 1;
        Exam.ItemData item = new Exam.ItemData();
        item.id = 3;
        item.count = countC;
        item.costGold = 0;
        item.materialList = new List<Exam.MaterialData>();
        material.item = item;
        return material;
    }
    Exam.MaterialData ItemDataD()
    {
        Exam.MaterialData material = new Exam.MaterialData();
        material.count = 4;
        Exam.ItemData item = new Exam.ItemData();
        item.id = 4;
        item.count = 0;
        item.costGold = 58;
        item.materialList = new List<Exam.MaterialData>();
        item.materialList.Add(ItemDataG());
        material.item = item;
        return material;
    }
    Exam.MaterialData ItemDataE()
    {
        Exam.MaterialData material = new Exam.MaterialData();
        material.count = 1;
        Exam.ItemData item = new Exam.ItemData();
        item.id = 5;
        item.count = countE;
        item.costGold = 0;
        item.materialList = new List<Exam.MaterialData>();
        material.item = item;
        return material;
    }
    Exam.MaterialData ItemDataF()
    {
        Exam.MaterialData material = new Exam.MaterialData();
        material.count = 5;
        Exam.ItemData item = new Exam.ItemData();
        item.id = 6;
        item.count = countF;
        item.costGold = 0;
        item.materialList = new List<Exam.MaterialData>();
        material.item = item;
        return material;
    }
    Exam.MaterialData ItemDataG()
    {
        Exam.MaterialData material = new Exam.MaterialData();
        material.count = 9;
        Exam.ItemData item = new Exam.ItemData();
        item.id = 7;
        item.count = countG;
        item.costGold = 0;
        item.materialList = new List<Exam.MaterialData>();
        material.item = item;
        return material;
    }
    public class Exam
    {
        public class MaterialData
        {
            public ItemData item; //�ϳ��������Ʒ
            public int count; //�ϳ�����ĸ���Ʒ������
        }
        public class ItemData
        {
            public int id; //��Ʒ ID
            public int count; //��ǰӵ�е���Ʒ����
            public int costGold; //�ϳɸ���Ʒ����Ľ��
            public List<MaterialData> materialList; //�ϳɸ���Ʒ����Ĳ���
        }

        public void SetCount(MaterialData item, int newcount)
        {
            item.count = newcount;
        }
        /// <summary>
        /// ������ totalGold ��������Ժϳɵ� item װ��������
        /// </summary>
        /// <param name="item">Ҫ�ϳɵ�װ��</param>
        /// <param name="totalGold">ӵ�еĽ��</param>
        /// <returns>�ɺϳɵ� item װ�����������</returns>
        public int Run(ItemData item, int totalGold)
        {
            int count = item.materialList.Count;
            if (count == 0 || totalGold <= 0)
            {
                return item.count;
            }
            int number1 = 0, number2 = 0, minnumber = 0;
            for (int i = 0; i < count; i++)
            {
                number1 = Run(item.materialList[i].item, totalGold);
                number2 = number1 / item.materialList[i].count;
                if (i == 0)
                    minnumber = number2;
                minnumber = Mathf.Min(number2, minnumber);
            }
            return minnumber;
        }
    }  
}
