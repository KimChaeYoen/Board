# Board
This project is asp.net webform Board

★개발환경★
1. language : c#.net 
2. visual studio 2010
3. dbms : mssql 

**소스 실행방법***
★본 소스를 실행하는 순서입니다.★

[1] **SQL Server ManageMent Studio에서..아래의 과정을 순서대로!! 실행해주세요!

(1) 데이터베이스 생성
1. SQL Server ManageMent Studio에서 데이터베이스 이름을  chaeyoendb로  만들어줍니다.

(2) 테이블 생성
1.TABLE폴더 안에 있는 dbo.member를 실행한후, F5를 눌러 member 테이블을 생성합니다.
2. TABLE폴더 안에 있는 dbo.board를 실행한후, F5를 눌러 board 테이블을 생성합니다.
 

(3)프로시저 생성
1. SP폴더에 있는 dbo.DeleteBasic를 실행한후, F5를 눌러 DeleteBasic 프로시저를 생성합니다.
2. SP폴더에 있는dbo.Deletefile를 실행한후, F5를 눌러 Deletefile프로시저를 생성합니다.
3. SP폴더에 있는dbo.DownloadCount를 실행한후, F5를 눌러 DownloadCount프로시저를 생성합니다.
4. SP폴더에 있는 dbo.ListBasic를 실행한후, F5를 눌러 .ListBasic프로시저를 생성합니다.
5. SP폴더에 있는 dbo.Login실행한후, F5를 눌러 Login프로시저를 생성합니다.
6. SP폴더에 있는 dbo.ModifyBasic를 실행한후, F5를 눌러 ModifyBasic프로시저를 생성합니다.
7. SP폴더에 있는dbo.ReplyReply를 실행한후, F5를 눌러 ReplyReply프로시저를 생성합니다.
8. SP폴더에 있는 dbo.SearchBasic를 실행한후, F5를 눌러 SearchBasic프로시저를 생성합니다.
9. SP폴더에 있는 dbo.ViewBasic를 실행한후, F5를 눌러 ViewBasic프로시저를 생성합니다.
10. SP폴더에 있는dbo.WriteReply를 실행한후, F5를 눌러 WriteReply프로시저를 생성합니다.


[2] **Visual Studio 2010에서... 아래의 과정을 순서대로 실행해주세요!

1. 파일 - 열기 - 웹사이트 - [Board1] 열기
2. web.config에서 Catalog=chaeyeondb로 변경 및 UserID,Password 본인 것으로 설정합니다.
3. ☆☆☆Login.aspx를 실행하여 테스트합니다!!


***구현된 기능 ***

1. 계층형 게시판 CRUD기능(글작성,삭제,수정,상세보기)_완료
2. 파일첨부기능_완료
3. 유효성검사_ 완료 
4. 회원관리기능(로그인,로그아웃,회원가입)_완료








