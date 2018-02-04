$("#plot").click(function() {
    var data = {
        CoefficientA: $("#coefA").val(),
        CoefficientB: $("#coefB").val(),
        CoefficientC: $("#coefB").val(),
        rangeFrom:$("#rangeFrom").val(),
        rangeTo:$("#rangeTo").val(),
        step:$("#step").val()
    }
    $("#errormsg").text("");
    var err = false;
    var errMsg = "";
    if (data.CoefficientA.length == 0) {
        errMsg += "coefA is required.";
        err = true;
    }
    if (data.CoefficientB.length == 0) {
        errMsg += "coefB is required.";
        err = true;
    }
    if (data.CoefficientC.length == 0) {
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
                arrayPoints.push({ x:element.PointX,y: element.PointY})
            });
            var canvas = $("#myCanvas");
            var x = new Chart(canvas, {
                type: 'scatter',
                data: {
                   datasets: [{
                      label: "y = " + data.CoefficientA + "x^2 + " + data.CoefficientB + "x + " + data.CoefficientC,
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
  