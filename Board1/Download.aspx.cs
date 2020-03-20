using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Download : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        //1.커넥션
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["boarddbConnectionString4"].ConnectionString);
        con.Open();

        //2.커멘드
        SqlCommand cmd = new SqlCommand("DownloadCount", con);

        //3.프로시저
        cmd.CommandType = CommandType.StoredProcedure;

        //파라미터 : View.aspx에서 넘겨온 Num쿼리스트링값
        cmd.Parameters.AddWithValue("@Num", Request["Num"]);
     
        //다운로드 처리 
        cmd.ExecuteNonQuery();

        //커넥션 닫기
        con.Close();

        //4.임시 페이지의 내용을 모두 지움
        Response.Clear();

        string file = Request.QueryString["file"];

        //Application/UnKnown : MIME(알수없는 형식)
        Response.ContentType = "Application/UnKnown";

        //다운로드 안치고 인식됨
        Response.AddHeader("Content-Disposition", "Attachment;filename=" + HttpUtility.UrlEncode(file, Encoding.UTF8).Replace("+", "%20"));

        //해당 파일을 임시 페이지(출력 스트림)에 직접 씀
        //Response.WriteFile("files/" + file);
        //Response.End();

    }

}