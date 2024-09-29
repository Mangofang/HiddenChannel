import pymysql
import Access
import WebApi

def room_join(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select * from room where RoomId = %s"
        cursor.execute(sql, (RoomId))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("Room Not Found")
        else:
            sql = "select InRoom from User where Username = %s"
            cursor.execute(sql, (Username))
            InRoom = cursor.fetchall()[0]["InRoom"]
            InRoom_Arry = InRoom.split(",")
            for i in InRoom_Arry:
                if i == RoomId:
                    return("Already In Room")
            sql = "update User set InRoom = %s where Username = %s"
            str = InRoom + f",{RoomId}".replace(" ", "")
            cursor.execute(sql, (str, Username))
            connect.commit()
            cursor.close()
            connect.close()
            return "1"
    return "Unauthorized Access"
        
def room_quit(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select InRoom from User where Username = %s"
        cursor.execute(sql, (Username))
        InRoom = cursor.fetchall()[0]["InRoom"]
        InRoom_Arry = InRoom.split(",")
        a = 0
        for i in InRoom_Arry:
            if i == RoomId:
                InRoom_Arry.pop(a)
                break
            a += 1
        InRoom = str(InRoom_Arry).replace("[", "").replace("]", "").replace("'", "").replace(" ", "")
        sql = "update User set InRoom = %s where Username = %s"
        cursor.execute(sql, (InRoom, Username))
        connect.commit()
        cursor.close()
        connect.close()
        return "1"
    return "Unauthorized Access"
    
def room_create(Username,Session,RoomName,PublicKey,Info):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select RoomId from room"
        cursor.execute(sql)
        RoomId = len(cursor.fetchall()) + 1
        sql = "insert into room values (%s,%s,%s,%s,%s)"
        cursor.execute(sql, (RoomId, RoomName, Username, PublicKey, Info))
        connect.commit()
        cursor.close()
        connect.close()
        return str(RoomId)
    return "Unauthorized Access"

def room_delete(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select * from room where RoomId = %s and Own = %s"
        cursor.execute(sql, (RoomId, Username))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("Unauthorized Access")
        sql = "delete from room where RoomId = %s"
        cursor.execute(sql, (RoomId))
        connect.commit()
        cursor.close()
        connect.close()
        return "1"
    return "Unauthorized Access"

def delcreate(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select * from room where RoomId = %s and Own = %s"
        cursor.execute(sql, (RoomId, Username))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("Unauthorized Access")
        sql = "delete from room where RoomId = %s"
        cursor.execute(sql, (RoomId))
        connect.commit()
        cursor.close()
        connect.close()
        return "1"
    return "Unauthorized Access"

def get_roomname(RoomId):
    connect,cursor = WebApi.conn()
    sql = "select Name from room where RoomId = %s"
    cursor.execute(sql, (RoomId))
    if cursor.rowcount == 0:
        cursor.close()
        connect.close()
        return "0"
    else:
        RoomId = cursor.fetchone()
        cursor.close()
        connect.close()
        return str(RoomId["Name"])

def get_publickey(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select PublicKey from room where RoomId = %s"
        cursor.execute(sql, (RoomId))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("Unauthorized Access")
        PublicKey = cursor.fetchone()
        cursor.close()
        connect.close()
        return str(PublicKey["PublicKey"])
    return "Unauthorized Access"

def whoinroom(Username,Session,RoomId):
    connect,cursor = WebApi.conn()
    if(WebApi.checkuser(Username,Session) == "1"):
        sql = "select * from user where InRoom regexp %s"
        cursor.execute(sql, ("," + RoomId + "$"))
        if cursor.rowcount == 0:
            cursor.close()
            connect.close()
            return("Unauthorized Access")
        username = cursor.fetchall()
        cursor.close()
        connect.close()
        return username
    return "Unauthorized Access"