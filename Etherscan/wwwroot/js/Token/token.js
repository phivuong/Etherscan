function loadEditToken(id) {
    $.ajax({
        url: '/Token/Edit',
        data: { id: id },
        type: 'GET',
        success: function (data) {
            $('#createEditToken').html(data)
        },
        error: function () {
            console.log('Error')
        }
    });
}

function loadCreateToken() {
    $.ajax({
        url: '/Token/Create',
        type: 'GET',
        success: function (data) {
            $('#createEditToken').html(data)
        },
        error: function () {
            console.log('Error')
        }
    });
}

function loadChart() {
    $.ajax({
        url: '/Token/GetChartData',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            generateChart(data)
        },
        error: function () {
            console.log('Error')
        }
    });
}

function generateChart(data) {
    $('#donutChart').highcharts({
        chart: {
            type: 'pie'
        },
        title: {
            text: null
        },
        credits: {
            enabled: false
        },
        tooltip: {
            pointFormat: '{point.y:.5f}%'
        },
        plotOptions: {
            pie: {
                dataLabels: {
                    enabled: true,
                    formatter: function () {
                        if (this.y > 0) {
                            return Highcharts.numberFormat(this.point.percentage, 1) + ' %'
                        }
                    },
                    distance: -20,
                    color: '#000000'
                }
            }
        },
        series: [{
            size: '100%',
            innerSize: '40%',
            data: data,
            dataLabels: {
                formatter: function () {
                    return this.point.name;
                },
                distance: 10
            }
        }]
    });
}

function reset() {
    loadCreateToken();
}