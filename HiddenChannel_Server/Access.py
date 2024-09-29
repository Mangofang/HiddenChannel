import pymysql
import uuid
import json
import WebApi

def getroot():
    connect,cursor = WebApi.conn()
    sql = "select * from Room"
    cursor.execute(sql)
    cursor.close()
    connect.close()
    return(json.dumps(cursor.fetchall()))

def register(Username,Passwd):
    if(Username == "" or Passwd == ""):
        return("0")
    connect,cursor = WebApi.conn()
    sql = "select * from User where Username = %s"
    cursor.execute(sql, (Username))
    if cursor.rowcount == 0:
        sql = "insert into User (Username, Passwd, IsLogin, Session, InRoom) values (%s, %s, '0', '', '')"
        cursor.execute(sql, (Username, Passwd))
        connect.commit()
        cursor.close()
        connect.close()
        return("1")
    else:
        cursor.close()
        connect.close()
        return("0")
    
def login(Username,Passwd):
    if(Username == "" or Passwd == ""):
        return("0")
    connect,cursor = WebApi.conn()
    sql = "select * from User where Username = %s and Passwd = %s"
    cursor.execute(sql, (Username, Passwd))
    if cursor.rowcount == 0:
        cursor.close()
        connect.close()
        return(f"0")
    else:
        unique_id = uuid.uuid4()
        sql = "update User set IsLogin = '1',Session = %s where Username = %s"
        cursor.execute(sql, (unique_id,Username))
        connect.commit()
        cursor.close()
        connect.close()
        return(str(unique_id))
    
def logout(Username,Session):
    connect,cursor = WebApi.conn()
    sql = "select * from User where Username = %s and Session = %s and IsLogin = '1'"
    cursor.execute(sql, (Username, Session))
    if cursor.rowcount == 0:
        cursor.close()
        connect.close()
        return("Unauthorized Access")
    else:
        sql = "update User set IsLogin = '0',Session = '' where Username = %s"
        cursor.execute(sql, (Username))
        connect.commit()
        cursor.close()
        connect.close()
        return("1")
    
def joinedroom(Username,Session):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select InRoom from User where Username = %s"
        cursor.execute(sql, (Username))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("0")
        else:
            roomid = cursor.fetchone()['InRoom'].split(',')
            sql = "select * from Room where RoomId = %s"
            for i in range(len(roomid)):
                cursor.execute(sql, (roomid[i]))
                if cursor.rowcount == 0:
                    roomid[i] = "0"
                else:
                    roomid[i] = cursor.fetchone()
            cursor.close()
            connect.close()
            return(roomid)
    return "Unauthorized Access"
def mycreateroom(Username,Session):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select RoomId from Room where Own = %s"
        cursor.execute(sql, (Username))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("0")
        else:
            roomid = cursor.fetchall()
            sql = "select * from Room where RoomId = %s"
            for i in range(len(roomid)):
                cursor.execute(sql, (roomid[i]['RoomId']))
                if cursor.rowcount == 0:
                    roomid[i] = "0"
                else:
                    roomid[i] = cursor.fetchone()
            cursor.close()
            connect.close()
            return(roomid)
    return "Unauthorized Access"