from flask import Flask, request
import pymysql
import Access
import Room
import Messages

app = Flask(__name__)

#数据库连接字符串，需要修改
def conn():
    #修改数据库信息
    connect = pymysql.connect(host='YouHost', user='YouUserName', password='YouPasswd', db='HiddenChannel')
    cursor = connect.cursor(pymysql.cursors.DictCursor)
    return connect,cursor

#鉴权
def checkuser(Username,Session):
    connect,cursor = conn()
    sql = "select * from User where Username = %s and Session = %s and IsLogin = '1'"
    cursor.execute(sql, (Username, Session))
    if cursor.rowcount == 0:
        cursor.close()
        connect.close()
        return("0")
    return("1")

#注册用户
@app.route('/register', methods=['GET'])
def register():
    result = Access.register(request.args.get("Username"), request.args.get("Passwd"))
    return result

#登录用户，返回session
@app.route('/login', methods=['GET'])
def login():
    result = Access.login(request.args.get("Username"), request.args.get("Passwd"))
    return result

#登出用户，清除session
@app.route('/logout', methods=['GET'])
def logout():
    result = Access.logout(request.args.get("Username"), request.args.get("Session"))
    return result

#获取公共房间
@app.route('/getroom', methods=['GET'])
def getroom():
    result = Access.getroot()
    return result

#获取已加入的房间
@app.route('/joinedroom', methods=['GET'])
def joinedroot():
    result = Access.joinedroom(request.args.get("Username"), request.args.get("Session"))
    return result

#获取我创建的房间
@app.route('/mycreateroom', methods=['GET'])
def mycreateroom():
    result = Access.mycreateroom(request.args.get("Username"), request.args.get("Session"))
    return result

#加入房间
@app.route('/room/join', methods=['GET'])
def room_join():
    result = Room.room_join(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"))
    return result

#退出房间
@app.route('/room/quit', methods=['GET'])
def room_quit():
    result = Room.room_quit(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"))
    return result

#创建房间
@app.route('/room/create', methods=['GET','POST'])
def room_create():
    publickey = request.get_data().decode('utf-8')
    result = Room.room_create(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomName"), publickey, request.args.get("Info"))
    return result

#删除房间
@app.route('/room/delete', methods=['GET'])
def room_delete():
    result = Room.room_delete(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"))
    return result

#获取房间名称
@app.route('/room/get_roomname', methods=['GET'])
def room_get_info():
    result = Room.get_roomname(request.args.get("RoomId"))
    return result

#获取房间公钥
@app.route('/room/get_publickey', methods=['GET'])
def room_get_publickey():
    result = Room.get_publickey(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"))
    return result

#获取房间用户
@app.route('/room/whoinroom', methods=['GET'])
def room_whoinroom():
    result = Room.whoinroom(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"))
    return result

#获取房间消息
@app.route('/messages/get_message', methods=['GET'])
def get_message():
    result = Messages.get_message(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"))
    return result

#发送消息
@app.route('/messages/send_message', methods=['GET','POST'])
def send_message():
    Text = request.get_data().decode('utf-8')
    result = Messages.send_message(request.args.get("Username"), request.args.get("Session"), request.args.get("RoomId"), Text)
    return result

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=7890)