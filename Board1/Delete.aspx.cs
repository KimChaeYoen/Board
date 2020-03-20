using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections;

public partial class Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //비회원이 해당 주소를 알아내서 직접 접속했을때
        if (Session["id"] == null)
        {
            string script = "<script type='text/javascript'>alert('권한이 없습니다.로그인해주세요.');location.href='Default.aspx';</script>";
            Response.Write(script);
            Response.End();
        }

        var Sid = Session["id"].ToString();  // ToString써서 String값으로 변경해줘야 자료형 같아짐 밑의  Sid != Rid 비교에서 제대로 비교함!
        var Rid = Request["id"].ToString();   //ToString써서 String값으로 변경해줘야 자료형 같아짐 밑의  Sid != Rid 비교에서 제대로 비교함!

        //본인이 쓰지 않은 글인데 삭제하려고 했을때
        if (Sid != Rid)
        {
            string script = "<script type='text/javascript'>alert('본인이 쓴 글만 삭제가능합니다!');location.href='Default.aspx';</script>";
            Response.Write(script);
            Response.End();
        }

        // 넘겨져 온 번호 값 검사
        if (String.IsNullOrEmpty(Request["Num"]))
        {
            Response.Write("잘못된 요청입니다.");
            Response.End();
        }
        else
        {
            // 레이블에 넘겨져 온 번호 값 출력
            this.lblNum.Text = Request["Num"];
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
            
        //1.커넥션
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString4"].ConnectionString);
        conn.Open();

        //**답글이 있으면 삭제불가 메시지 뿌리기
        SqlCommand cmd2= new SqlCommand("Select @RCount = count(*) from board where @Num=replyChk", conn);
        // 파라미터 추가
        cmd2.Parameters.AddWithValue("@Num", Request["Num"]);
        cmd2.ExecuteScalar().ToString();
        string Rcount = cmd2.ExecuteScalar().ToString();
        if (Rcount != "0")//삭제할 글에 답변글이 있을 경우 
        { //'답글이 있어 삭제불가'알람처리 
            string script = "";
            script = "<script type='text/javascript'>alert('답글이 있어 삭제불가!목록으로 이동합니다'); location.href='Default.aspx';</script>";
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "delete", script);
        }
        else//삭제할 글에 답변글이 없을 경우 
        {


            //2.커멘드
            SqlCommand cmd = new SqlCommand("DeleteBasic", conn);

            //3.프로시저
            cmd.CommandType = CommandType.StoredProcedure;

            //파라미터 : Default.aspx에서 넘겨온 쿼리스트링값
            cmd.Parameters.AddWithValue("@Num", Request["Num"]);

            //삭제처리 
            cmd.ExecuteNonQuery();

            //삭제알림처리한후에 게시판으로 이동              
            string script2 = "";
            script2 = "<script type='text/javascript'>alert('삭제되었습니다.목록으로 이동합니다'); location.href='Default.aspx';</script>";
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "delete", script2);

        }
                    
                  
    }

    



    // 번호와 암호가 맞으면 참을 반환, 그렇지 않으면 거짓을 반환
    private bool IsPasswordCorrect()
    {
        bool result = false;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString4"].ConnectionString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * From board Where Num = @Num And Password = @Password", conn);

        // 파라미터 추가
        cmd.Parameters.AddWithValue("@Num", Request["Num"]);
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read()) //데이터가 읽혀진다면, 번호와 암호가 맞음
        {
            result = true;
        }
        return result;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // 취소 버튼 클릭시 뒤로(상세 보기 페이지) 이동
        Response.Redirect("View.aspx?Num=" + Request["Num"]);
    }

    public DataSet dataSet { get; set; }
    public DataTable getRelationBoard { get; set; }
}