var list = [];
list.push({ "key": 'A', "value": 1 });
list.push({ "key": 'B', "value": 2 });
list.push({ "key": 'C', "value": 3 });
list.push({ "key": 'D', "value": 4 });
list.push({ "key": 'E', "value": 5 });
list.push({ "key": 'F', "value": 6 });
list.push({ "key": 'G', "value": 7 });
list.push({ "key": 'H', "value": 8 });
list.push({ "key": 'J', "value": 1 });
list.push({ "key": 'K', "value": 2 });
list.push({ "key": 'L', "value": 3 });
list.push({ "key": 'M', "value": 4 });
list.push({ "key": 'N', "value": 5 });
list.push({ "key": 'P', "value": 7 });
list.push({ "key": 'R', "value": 9 });
list.push({ "key": 'S', "value": 2 });
list.push({ "key": 'T', "value": 3 });
list.push({ "key": 'U', "value": 4 });
list.push({ "key": 'V', "value": 5 });
list.push({ "key": 'W', "value": 6 });
list.push({ "key": 'X', "value": 7 });
list.push({ "key": 'Y', "value": 8 });
list.push({ "key": 'Z', "value": 9 });
list.push({ "key": '0', "value": 0 });
list.push({ "key": '1', "value": 1 });
list.push({ "key": '2', "value": 2 });
list.push({ "key": '3', "value": 3 });
list.push({ "key": '4', "value": 4 });
list.push({ "key": '5', "value": 5 });
list.push({ "key": '6', "value": 6 });
list.push({ "key": '7', "value": 7 });
list.push({ "key": '8', "value": 8 });
list.push({ "key": '9', "value": 9 });

function findThis(obj) {
    //console.log(this);
    //alert(this);
    //console.log(obj.key == this.PrimitiveValue);
    //console.log(obj.key);
    return obj.key == this;
}

function vaildateVIN(VIN) {
    //console.log(list);
    VIN = VIN.trim().toUpperCase();
    //alert(VIN);
    
    if (VIN.length != 17) {
        return false;
    }
    var char_VIN =VIN.split("");
    var res = new Array(17);
    //console.log(char_VIN);
    var num = [
        8,7,6,5,4,3,2,10,0,9,8,7,6,5,4,3,2
            ];
    var count = 0;
    for (var i = 0; i < res.length; i++)
    {
        //console.log(char_VIN[i]);
        var temp = list.find(findThis, char_VIN[i]);
        if (temp!=null){
            res[i] = temp.value * num[i];
            count += res[i];
        } else {
            return false;
        }
        //console.log("-------------------------");
        //console.log(temp);
        //console.log(temp.value);

    }
    var result = count % 11;
    var c9 = char_VIN[8];
    if (c9.toString() == "X") {
        if (result.toString()=="10"){
            return true;
        } else {
            return false;
        }
    }
    return result.toString() == c9.toString();
}

