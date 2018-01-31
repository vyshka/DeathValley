$("#plot").click(function() {
    var data = {
        coefA: $("#coefA").val(),
        coefB:$("#coefB").val(),
        coefC:$("#coefB").val(),
        rangeFrom:$("#rangeFrom").val(),
        rangeTo:$("#rangeTo").val(),
        step:$("#step").val()
    }
    $("#errormsg").text("");
    var err = false;
    var errMsg = "";
    if (data.coefA.length == 0) {
        errMsg += "coefA is required.";
        err = true;
    }
    if (data.coefB.length == 0) {
        errMsg += "coefB is required.";
        err = true;
    }
    if (data.coefC.length == 0) {
        errMsg += "coefA is required.";
        err = true;
    }
    if (data.step.length == 0) {
        errMsg += "step is required.";
        err = true;
    }
    if (data.rangeFrom.length == 0) {
        errMsg += "rangeFrom is required.";
        err = true;
    }
    if (data.rangeTo.length == 0) {
        errMsg += "rangeTo is required.";
        err = true;
    }
    if(data.rangeTo <= data.rangeFrom) {
        errMsg += "rangeTo must be greater then rangeFrom.";
        err = true;
    }
    if(err) {
        $("#errormsg").text(errMsg);
        return;
    }
     
    $.ajax({
        url: '/Home/Calculate',
        type: 'post',
        dataType: 'json',
        success: function (returnData) {
            if(returnData.success == false) {
                $("#errormsg").text(returnData.response);
                return;
            }
            var arrayPoints = new Array();
            returnData.forEach(element => {
                arrayPoints.push({ x:element._x,y: element._y})
            });
            var canvas = $("#myCanvas");
            var x = new Chart(canvas, {
                type: 'scatter',
                data: {
                   datasets: [{
                      label: "y = " + data.coefA + "x^2 + " + data.coefB + "x + " + data.coefC,
                      data: arrayPoints,
                   }]
                },
                options: {
                   responsive: true
                }
             });
            
        },
        data: data
    });
  });
  