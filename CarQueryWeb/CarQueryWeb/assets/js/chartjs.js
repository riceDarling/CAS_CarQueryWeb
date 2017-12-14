//$(function () {    
//  var ctx, data, myLineChart, options;
//  Chart.defaults.global.responsive = true;
//  if ($('#line-chart-gas-checkMethod').get(0)!=null){
//      ctx = $('#line-chart-gas-checkMethod').get(0).getContext('2d'); 
//  }
  
//  options = {
//    scaleShowGridLines: true,
//    scaleGridLineColor: "rgba(0,0,0,.05)",
//    scaleGridLineWidth: 1,
//    scaleShowHorizontalLines: true,
//    scaleShowVerticalLines: true,
//    bezierCurve: true,
//    bezierCurveTension: 0.4,
//    pointDot: true,
//    pointDotRadius: 4,
//    pointDotStrokeWidth: 1,
//    pointHitDetectionRadius: 20,
//    datasetStroke: true,
//    datasetStrokeWidth: 2,
//    datasetFill: false,
//    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
//  };
//  data = {
//    labels: ['第一月', '第二月', '第三月', '第四月', '第五月', '第六月', '第七月'],
//    datasets: [
//      {
//        label: "稳态",
//        fillColor: "rgba(26, 188, 156,0.2)",
//        strokeColor: "#1ABC9C",
//        pointColor: "#1ABC9C",
//        pointStrokeColor: "#fff",
//        pointHighlightFill: "#fff",
//        pointHighlightStroke: "#1ABC9C",
//        data: [65, 59, 80, 81, 56, 55, 40]
//      }, {
//        label: "双怠速",
//        fillColor: "rgba(34, 167, 240,0.2)",
//        strokeColor: "#22A7F0",
//        pointColor: "#22A7F0",
//        pointStrokeColor: "#fff",
//        pointHighlightFill: "#fff",
//        pointHighlightStroke: "#22A7F0",
//        data: [28, 48, 40, 19, 86, 27, 90]
//      }
//    ]
//  };
//  myLineChart = new Chart(ctx).Line(data, options);
//    //line-chart-gas-checkMethod-legend
//  var legenfHtml = "";
//  legenfHtml += "<div class='chart'><div class='pie '><ul class='pie-legend' style=\"float:right;\" type='none'>";
//  for (i = 0; i < data.datasets.length; i++) {
//      var tempColor = data.datasets[i].fillColor;
//      legenfHtml += ("<li><span style=\"float:left;width:14px;height:14px;background-color:" + tempColor + "\"></span>" + data.datasets[i].label + "</li>");
//  }
//  legenfHtml += "</ul></div></div>";
//  document.getElementById("line-chart-gas-checkMethod-legend").innerHTML = legenfHtml;

//});
//$(function () {
//    var ctx, data, myBarChart, option_bars;
//    Chart.defaults.global.responsive = true;
//    ctx = $('#line-chart-diesel-checkMethod').get(0).getContext('2d');
//    option_bars = {
//        scaleBeginAtZero: true,
//        scaleShowGridLines: true,
//        scaleGridLineColor: "rgba(0,0,0,.05)",
//        scaleGridLineWidth: 1,
//        scaleShowHorizontalLines: true,
//        scaleShowVerticalLines: false,
//        barShowStroke: true,
//        barStrokeWidth: 1,
//        barValueSpacing: 5,
//        bezierCurve: true,//是否为曲线
//        barDatasetSpacing: 3,
//        datasetFill: false,
//        legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
//    };
//    data = {
//        labels: ['第一月', '第二月', '第三月', '第四月', '第五月', '第六月', '第七月'],
//        datasets: [
//          {
//              label: "加载减速",
//              fillColor: "rgba(26, 188, 156,0.6)",
//              strokeColor: "#1ABC9C",
//              pointColor: "#1ABC9C",
//              pointStrokeColor: "#fff",
//              pointHighlightFill: "#fff",
//              pointHighlightStroke: "#1ABC9C",
//              data: [65, 59, 80, 81, 56, 55, 40]
//          }, {
//              label: "不透光烟度",
//              fillColor: "rgba(34, 167, 240,0.6)",
//              strokeColor: "#22A7F0",
//              pointColor: "#22A7F0",
//              pointStrokeColor: "#fff",
//              pointHighlightFill: "#fff",
//              pointHighlightStroke: "#22A7F0",
//              data: [28, 48, 40, 19, 86, 27, 90]
//          }
//        ]
//    };
//    myBarChart = new Chart(ctx).Line(data, option_bars); 
//    var legenfHtml = "";
//    legenfHtml += "<div class='chart'><div class='pie '><ul class='pie-legend' style=\"float:right;\" type='none'>";
//    for (i = 0; i < data.datasets.length; i++) {
//        var tempColor = data.datasets[i].fillColor;
//        legenfHtml += ("<li><span style=\"float:left;width:14px;height:14px;background-color:" + tempColor + "\"></span>" + data.datasets[i].label + "</li>");
//    }
//    legenfHtml += "</ul></div></div>";
//    document.getElementById("line-chart-diesel-checkMethod-legend").innerHTML = legenfHtml;
//});

//$(function() {
//  var ctx, data, myBarChart, option_bars;
//  Chart.defaults.global.responsive = true;
//  ctx = $('#bar-chart-gas-checkMethod').get(0).getContext('2d');
//  option_bars = {
//    scaleBeginAtZero: true,
//    scaleShowGridLines: true,
//    scaleGridLineColor: "rgba(0,0,0,.05)",
//    scaleGridLineWidth: 1,
//    scaleShowHorizontalLines: true,
//    scaleShowVerticalLines: false,
//    barShowStroke: true,
//    barStrokeWidth: 1,
//    barValueSpacing: 5,
//    barDatasetSpacing: 3,
//    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
//  };
//  data = {
//      labels: ['第一月', '第二月', '第三月', '第四月', '第五月', '第六月', '第七月'],
//    datasets: [
//      {
//        label: "稳态",
//        fillColor: "rgba(26, 188, 156,0.6)",
//        strokeColor: "#1ABC9C",
//        pointColor: "#1ABC9C",
//        pointStrokeColor: "#fff",
//        pointHighlightFill: "#fff",
//        pointHighlightStroke: "#1ABC9C",
//        data: [65, 59, 80, 81, 56, 55, 40]
//      }, {
//        label: "双怠速",
//        fillColor: "rgba(34, 167, 240,0.6)",
//        strokeColor: "#22A7F0",
//        pointColor: "#22A7F0",
//        pointStrokeColor: "#fff",
//        pointHighlightFill: "#fff",
//        pointHighlightStroke: "#22A7F0",
//        data: [28, 48, 40, 19, 86, 27, 90]
//      }
//    ]
//  };
//  myBarChart = new Chart(ctx).Bar(data, option_bars);
//  var legenfHtml="";
//  legenfHtml += "<div class='chart'><div class='pie '><ul class='pie-legend' style=\"float:right;\" type='none'>";
//  for (i = 0; i < data.datasets.length; i++) {
//      var tempColor=data.datasets[i].fillColor;
//      legenfHtml += ("<li><span style=\"float:left;width:14px;height:14px;background-color:" + tempColor + "\"></span>" + data.datasets[i].label + "</li>");
//  }
//  legenfHtml += "</ul></div></div>";
//  document.getElementById("bar-chart-gas-checkMethod-legend").innerHTML = legenfHtml;
//});
//$(function () {
//    var ctx, data, myBarChart, option_bars;
//    Chart.defaults.global.responsive = true;
//    ctx = $('#bar-chart-diesel-checkMethod').get(0).getContext('2d');
//    option_bars = {
//        scaleBeginAtZero: true,
//        scaleShowGridLines: true,
//        scaleGridLineColor: "rgba(0,0,0,.05)",
//        scaleGridLineWidth: 1,
//        scaleShowHorizontalLines: true,
//        scaleShowVerticalLines: false,
//        barShowStroke: true,
//        barStrokeWidth: 1,
//        barValueSpacing: 5,
//        barDatasetSpacing: 3,
//        legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
//    };
//    data = {
//        labels: ['第一月', '第二月', '第三月', '第四月', '第五月', '第六月', '第七月'],
//        datasets: [
//          {
//              label: "加载减速",
//              fillColor: "rgba(26, 188, 156,0.6)",
//              strokeColor: "#1ABC9C",
//              pointColor: "#1ABC9C",
//              pointStrokeColor: "#fff",
//              pointHighlightFill: "#fff",
//              pointHighlightStroke: "#1ABC9C",
//              data: [65, 59, 80, 81, 56, 55, 40]
//          }, {
//              label: "不透光烟度",
//              fillColor: "rgba(34, 167, 240,0.6)",
//              strokeColor: "#22A7F0",
//              pointColor: "#22A7F0",
//              pointStrokeColor: "#fff",
//              pointHighlightFill: "#fff",
//              pointHighlightStroke: "#22A7F0",
//              data: [28, 48, 40, 19, 86, 27, 90]
//          }
//        ]
//    };
//    myBarChart = new Chart(ctx).Bar(data, option_bars);
//    //bar-chart-diesel-checkMethod-legend
//    var legenfHtml = "";
//    legenfHtml += "<div class='chart'><div class='pie '><ul class='pie-legend' style=\"float:right;\" type='none'>";
//    for (i = 0; i < data.datasets.length; i++) {
//        var tempColor = data.datasets[i].fillColor;
//        legenfHtml += ("<li><span style=\"float:left;width:14px;height:14px;background-color:" + tempColor + "\"></span>" + data.datasets[i].label + "</li>");
//    }
//    legenfHtml += "</ul></div></div>";
//    document.getElementById("bar-chart-diesel-checkMethod-legend").innerHTML = legenfHtml;
//});
/*
$(function() {
  var ctx, data, myBarChart, option_bars;
  Chart.defaults.global.responsive = true;
  ctx = $('#radar-chart').get(0).getContext('2d');
  option_bars = {
    scaleBeginAtZero: true,
    scaleShowGridLines: true,
    scaleGridLineColor: "rgba(0,0,0,.05)",
    scaleGridLineWidth: 1,
    scaleShowHorizontalLines: true,
    scaleShowVerticalLines: false,
    barShowStroke: false,
    barStrokeWidth: 0,
    barValueSpacing: 5,
    barDatasetSpacing: 1,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
  };
  data = {
    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
    datasets: [
      {
        label: "My First dataset",
        fillColor: "rgba(26, 188, 156,0.2)",
        strokeColor: "#1ABC9C",
        pointColor: "#1ABC9C",
        pointStrokeColor: "#fff",
        pointHighlightFill: "#fff",
        pointHighlightStroke: "#1ABC9C",
        data: [65, 59, 80, 81, 56, 55, 40]
      }, {
        label: "My Second dataset",
        fillColor: "rgba(34, 167, 240,0.2)",
        strokeColor: "#22A7F0",
        pointColor: "#22A7F0",
        pointStrokeColor: "#fff",
        pointHighlightFill: "#fff",
        pointHighlightStroke: "#22A7F0",
        data: [28, 48, 40, 19, 86, 27, 90]
      }
    ]
  };
  myBarChart = new Chart(ctx).Radar(data, option_bars);
});

$(function() {
  var ctx, data, myPolarAreaChart, option_bars;
  Chart.defaults.global.responsive = true;
  ctx = $('#polar-area-chart').get(0).getContext('2d');
  option_bars = {
    scaleShowLabelBackdrop: true,
    scaleBackdropColor: "rgba(255,255,255,0.75)",
    scaleBeginAtZero: true,
    scaleBackdropPaddingY: 2,
    scaleBackdropPaddingX: 2,
    scaleShowLine: true,
    segmentShowStroke: true,
    segmentStrokeColor: "#fff",
    segmentStrokeWidth: 2,
    animationSteps: 100,
    animationEasing: "easeOutBounce",
    animateRotate: true,
    animateScale: false,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<segments.length; i++){%><li><span style=\"background-color:<%=segments[i].fillColor%>\"></span><%if(segments[i].label){%><%=segments[i].label%><%}%></li><%}%></ul>"
  };
  data = [
    {
      value: 300,
      color: "#FA2A00",
      highlight: "#FA2A00",
      label: "Red"
    }, {
      value: 50,
      color: "#1ABC9C",
      highlight: "#1ABC9C",
      label: "Green"
    }, {
      value: 100,
      color: "#FABE28",
      highlight: "#FABE28",
      label: "Yellow"
    }, {
      value: 40,
      color: "#999",
      highlight: "#999",
      label: "Grey"
    }, {
      value: 120,
      color: "#22A7F0",
      highlight: "#22A7F0",
      label: "Blue"
    }
  ];
  myPolarAreaChart = new Chart(ctx).PolarArea(data, option_bars);
});

$(function() {
  var ctx, data, myLineChart, options;
  Chart.defaults.global.responsive = true;
  ctx = $('#pie-chart').get(0).getContext('2d');
  options = {
    showScale: false,
    scaleShowGridLines: false,
    scaleGridLineColor: "rgba(0,0,0,.05)",
    scaleGridLineWidth: 0,
    scaleShowHorizontalLines: false,
    scaleShowVerticalLines: false,
    bezierCurve: false,
    bezierCurveTension: 0.4,
    pointDot: false,
    pointDotRadius: 0,
    pointDotStrokeWidth: 2,
    pointHitDetectionRadius: 20,
    datasetStroke: true,
    datasetStrokeWidth: 4,
    datasetFill: true,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
  };
  data = [
    {
      value: 300,
      color: "#FA2A00",
      highlight: "#FA2A00",
      label: "Red"
    }, {
      value: 50,
      color: "#1ABC9C",
      highlight: "#1ABC9C",
      label: "Green"
    }, {
      value: 100,
      color: "#FABE28",
      highlight: "#FABE28",
      label: "Yellow"
    }
  ];
  myLineChart = new Chart(ctx).Pie(data, options);
});

$(function() {
  var ctx, data, myLineChart, options;
  Chart.defaults.global.responsive = true;
  ctx = $('#jumbotron-line-chart').get(0).getContext('2d');
  options = {
    showScale: false,
    scaleShowGridLines: true,
    scaleGridLineColor: "rgba(0,0,0,.05)",
    scaleGridLineWidth: 1,
    scaleShowHorizontalLines: true,
    scaleShowVerticalLines: true,
    bezierCurve: false,
    bezierCurveTension: 0.4,
    pointDot: true,
    pointDotRadius: 4,
    pointDotStrokeWidth: 1,
    pointHitDetectionRadius: 20,
    datasetStroke: true,
    datasetStrokeWidth: 2,
    datasetFill: true,
    legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].strokeColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"
  };
  data = {
    labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
    datasets: [
      {
        label: "My Second dataset",
        fillColor: "rgba(34, 167, 240,0.2)",
        strokeColor: "#22A7F0",
        pointColor: "#22A7F0",
        pointStrokeColor: "#fff",
        pointHighlightFill: "#fff",
        pointHighlightStroke: "#22A7F0",
        data: [28, 48, 40, 45, 76, 65, 90]
      }
    ]
  };
  myLineChart = new Chart(ctx).Line(data, options);
});
*/