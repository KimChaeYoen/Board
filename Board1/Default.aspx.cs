using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //그리드뷰 컨트롤에 데이터 출력
        DisplayData();

        //그리드뷰 꾸미기
        //boardList.BorderColor = Color.SteelBlue;
       // boardList.BackColor = Color.WhiteSmoke;
  

    }
    private void DisplayData()
    {

        //1.커넥션
        SqlConnection con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["boarddbConnectionString4"].ConnectionString); 

        //2.커멘드
        SqlCommand cmd = new SqlCommand("ListBasic", con);
        //3.프로시저 
        cmd.CommandType = CommandType.StoredProcedure;

        //4.데이터어뎁터
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        //5.데이터 셋
        DataSet ds = new DataSet();

        //6.Fill()
        da.Fill(ds, "board");
       

        //7.바인딩
        this.boardList.DataSource = ds.Tables[0];
        this.boardList.DataBind();

    }


    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        boardList.PageIndex = e.NewPageIndex;

        this.BindGrid();
    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {

        //검색페이지로 필드명과 검색어 전달
        string strUrl =

            String.Format(
            "Search.aspx?SearchField={0}&SearchQuery={1}"
            , lstSearchField.SelectedValue
            , txtSearchQuery.Text
            );

        Response.Redirect(strUrl);

    }


    protected void btnWrite_Click(object sender, EventArgs e)
    {

        //글쓰기 페이지로 이동
        Response.Redirect("Write.aspx");

    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["boarddbConnectionString4"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            if (Session["id"] == null) //세션 id가 null이면 
            {
            }
            else
            {
                
            }

            using (SqlCommand cmd = new SqlCommand("SELECT name,title,ReadCount,id FROM board as b inner join member as m on b.id = m.id order by [Num] desc")) 
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);        
                        boardList.DataSource = dt;
                        boardList.DataBind();
                  
                    }
                }
            }
        }
    }
    
    //답변글에 이미지 삽입하는 이벤트 처리 
    protected void boardList_RowDataBound(object sender, GridViewRowEventArgs e) 
    {
     
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            
            DataRowView row = e.Row.DataItem as DataRowView;


            /******테스트 start****/
            //데이터값 가져오기

            //DataRowView dr = (DataRowView)e.Row.DataItem;

            //Label dl = (Label)e.Row.FindControl("USER_ID");// 이름의 컨트롤 찾기

            //if (dl != null)
            //{   //dl이 가르키는 DB네 컬럼명을 dr에 값으로 찾게한다.
            //    //**** USER_ID값 넣기
            //    if (Session["id"] == null) //세션 id가 null이면 
            //    {
            //    }
            //    else
            //    {
                  
            //        dl.Text = Session["id"].ToString();//***문제점.... DB에 있는 id를 들고와야하는데 session값을 가져오니까...로그인,로그아웃 될때마다 id필드가 쏴라락..그냥 바뀜
                    

            //    }

            //}


            //답변글은 제목앞에 re.gif 붙이기
            int depth = (int)row["Step"];
            if (depth > 0)
            {
                LiteralControl img = new LiteralControl("<img src='image/re5.png' alt='' style='margin-right:5px;margin-left:" + (depth * 15) + "px' />");
        
                //셀에 이미지 삽입
                e.Row.Cells[2].Controls.AddAt(0, img);
                //e.Row.Cells[0].Text = "";
            }
        }
    }


}
