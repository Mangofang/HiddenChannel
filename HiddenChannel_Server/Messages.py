import pymysql
import WebApi

def get_message(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select * from messages where RoomId = %s"
        cursor.execute(sql, (RoomId))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("0")
        else:
            result = cursor.fetchall()
            cursor.close()
            connect.close()
            return result
    return "Unauthorized Access"
def send_message(Username,Session,RoomId,Text):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "insert into messages (RoomId,Username,Text) values (%s,%s,%s)"
        cursor.execute(sql, (RoomId,Username,Text))
        connect.commit()
        cursor.close()
        connect.close()
        return("1")
    return "Unauthorized Access"