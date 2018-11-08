using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //创建一个HistoryTestInfo对象，保存到Session中
            //此对象用于保存用户做题的历史信息
            Session["scoreInfo"] = new HistoryTestInfo();
            //随机生成一个题目
            GenerateTestInfo();
        }

    }
    /// <summary>
    /// 当前正在做的题目
    /// </summary>
    private TestInfo curTest = null;
    /// <summary>
    /// 成绩信息
    /// </summary>
    private HistoryTestInfo scoreInfo = null;
   

    //随机生成一道题目
    private void GenerateTestInfo()
    {
        Random ran = new Random();
        //生成两个整数
        int num1 = ran.Next(1, 100);
        int num2 = ran.Next(1, 100);
        curTest = new TestInfo();
        curTest.MathExpression = num1.ToString() + "+" + num2.ToString();
        curTest.CorrectAnswer = num1 + num2;
       //保存到视图状态中，准备用于判断答案
        ViewState["curTest"] = curTest;

        //显示在页面上
        lblTest.Text = curTest.MathExpression+"=?";
        txtUserInput.Text = "";
        txtUserInput.Focus();
      
    }


  

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //是否视图状态中有题目
        if (ViewState["curTest"] == null)
            return;
        //去掉首尾空格查看用户是否输入了答案
        if (txtUserInput.Text.Trim().Length == 0)
        {
            lblPrompt.Text = "请在文本框中输入答案后再提交。";
            txtUserInput.Focus(); //焦点回到文本框
            return;
        }

        int result = Convert.ToInt32(txtUserInput.Text.Trim());

        TestInfo test=ViewState["curTest"] as TestInfo;
        HistoryTestInfo obj = Session["scoreInfo"] as HistoryTestInfo;
        //做题总数增一
        obj.TestCount++;
        //做对了
        if (result == test.CorrectAnswer)
        {
            lblPrompt.Text = "提示：您做对了，真棒！继续努力！";
            //正确题目总数增一
            obj.CorrectCount++;
        }
        else //没做对
        {
            lblPrompt.Text = "提示：" + test.MathExpression + "=" + test.CorrectAnswer.ToString() + "，提交的计算结果为" + txtUserInput.Text.Trim() + "， 答案不对。";
        }

        //显示统计信息
        string staticsInfo = "答题统计：一共做了{0}题，其中做对的{1}题，正确率为{2}%。";
        staticsInfo = string.Format(staticsInfo,obj.TestCount, obj.CorrectCount, (float)obj.CorrectCount / (float)obj.TestCount * 100);
        lblStatistic.Text = staticsInfo;
        //继续做下一题
        GenerateTestInfo();
    }
}
