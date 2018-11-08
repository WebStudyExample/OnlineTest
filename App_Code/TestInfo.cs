using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// 考试题目类
/// </summary>
[Serializable]
public class TestInfo
{
    //加法题目
    public string MathExpression = "";
    //用户输入的答案
    //public int UserAnswer = 0;
    //正确的答案
    public int CorrectAnswer = 0;
}

/// <summary>
/// 做题的历史信息
/// </summary>
[Serializable]
public class HistoryTestInfo
{
    //一共做了几题
    public int TestCount = 0;
    //做对了几题
    public int CorrectCount = 0;
}