using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class ExamplesDynamicTableNormal : MonoBehaviour
{
    public DynamicTableNormal HorizontalDynamicTableNormal;
    public DynamicTableNormal VerticalDynamicTableNormal;

    public Button BtnHorizontal;
    public Button BtnVertical;
    public Button m_btnGoto;
    public Button m_btnOnlyRrefreshData;
    public InputField m_inputField;
    public InputField m_inputFieldCount;
    int m_value = 1;
    void Start()
    {
        BtnHorizontal.onClick.AddListener(OnBtnHorizontalClick);
        BtnVertical.onClick.AddListener(OnBtnVerticalClick);
        m_btnGoto.onClick.AddListener(OnBtnGoto);
        m_btnOnlyRrefreshData.onClick.AddListener(OnBtnOnlyRefrehData);


        HorizontalDynamicTableNormal.DynamicTableGridDelegate = OnHorizontalDynamicTableViewCallBack;
        VerticalDynamicTableNormal.DynamicTableGridDelegate = OnHorizontalDynamicTableViewCallBack;

    }


    //设置item回调
    private void OnHorizontalDynamicTableViewCallBack(int evt, int index, DynamicGrid grid)
    {
        //传递grid的好处比传递go，可以省去每次的gameObject:GetComponet
        Debug.Log($"OnHorizontalDynamicTableViewCallBack:evt:{evt}-index:{index}");
        if (evt == (int)LayoutRule.DYNAMIC_DELEGATE_EVENT.DYNAMIC_GRID_ATINDEX)
        {
            TestNormalGrid testGrid = grid as TestNormalGrid;
            testGrid.SetContent($"{index}-{m_value}");
        }
        else if (evt == (int)LayoutRule.DYNAMIC_DELEGATE_EVENT.DYNAMIC_GRID_TOUCHED)
        {
            PublicFunc.Log($"点击了{index}");
        }
    }

    void OnBtnHorizontalClick()
    {
        HorizontalDynamicTableNormal.SetTotalCount(100);
        //HorizontalDynamicTableNormal.ReloadDataAsync();
    }

    void OnBtnVerticalClick()
    {
        VerticalDynamicTableNormal.SetTotalCount(100,75);
        //VerticalDynamicTableNormal.ReloadDataSync(75);
        //VerticalDynamicTableNormal.ReloadDataAsync();
    }

    void OnBtnGoto()
    {
        //检测索引是否越界跳转位置，否则保持当前位置，只更新当前显示的Grid
        int gotoNum = 75;
        int.TryParse(m_inputField.text, out gotoNum);

        //如果使用异步重置数据，会导致是慢慢刷出格子。
        VerticalDynamicTableNormal.ReloadDataSync(gotoNum);
        HorizontalDynamicTableNormal.ReloadDataSync(gotoNum);
    }

    void OnBtnOnlyRefrehData()
    {
        m_value++;
        int count = 100;
        if (int.TryParse(m_inputFieldCount.text, out count) == false)
        {
            count = 100;
        }

        int gotoNum = 75;
        if (int.TryParse(m_inputField.text, out gotoNum) == false)
        {
            gotoNum = -1;
        }
        VerticalDynamicTableNormal.SetTotalCount(count, gotoNum);
        HorizontalDynamicTableNormal.SetTotalCount(count, gotoNum);
        //VerticalDynamicTableNormal.ReloadDataSync(VerticalDynamicTableNormal.StartIndex);
        //刷新当前item显示
        //VerticalDynamicTableNormal.RefreshCurItems();
    }
}
