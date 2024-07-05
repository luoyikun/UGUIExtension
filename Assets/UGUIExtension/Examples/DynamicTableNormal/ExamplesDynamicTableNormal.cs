using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //Debug.Log($"OnHorizontalDynamicTableViewCallBack:evt:{evt}-index:{index}");
        if (evt == (int)LayoutRule.DYNAMIC_DELEGATE_EVENT.DYNAMIC_GRID_ATINDEX)
        {
            TestNormalGrid testGrid = grid as TestNormalGrid;
            testGrid.SetContent(index);
        }
        else if (evt == (int)LayoutRule.DYNAMIC_DELEGATE_EVENT.DYNAMIC_GRID_TOUCHED)
        {
            PublicFunc.Log($"点击了{index}");
        }
    }

    void OnBtnHorizontalClick()
    {
        HorizontalDynamicTableNormal.SetTotalCount(100);
        HorizontalDynamicTableNormal.ReloadDataAsync();
    }

    void OnBtnVerticalClick()
    {
        VerticalDynamicTableNormal.SetTotalCount(100);
        VerticalDynamicTableNormal.ReloadDataAsync();
    }

    void OnBtnGoto()
    {
        //检测索引是否越界跳转位置，否则保持当前位置，只更新当前显示的Grid
        int gotoNum = 75;
        int.TryParse(m_inputField.text, out gotoNum);

        VerticalDynamicTableNormal.ResetStartIndex(gotoNum);
        //设置容器偏移
        VerticalDynamicTableNormal.SetContentOffest();
    }

    void OnBtnOnlyRefrehData()
    {
        VerticalDynamicTableNormal.SetTotalCount(120);
    }
}
