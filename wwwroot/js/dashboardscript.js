const last30DaysData = {
        labels: last30DaysLabels,
        datasets: [{
            label: 'Actions per day',
            data: last30DaysActivity, // Access model data here
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 2,
            fill: false
        }]
    };

    const last24HoursData = {
        labels: last24labels,
        datasets: [{
            label: 'Actions per hour',
            data: last24data,
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 2,
            fill: false
        }]
    };

    const chartConfig = {
        type: 'line',
        data: null, // Will be set dynamically
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                x: {
                    type: 'category',
                    beginAtZero: true
                },
                y: {
                    beginAtZero: true
                }
            }
        }
    };

    // Initialize charts
const last30DaysChart = new Chart(document.getElementById('last30DaysChart'), chartConfig);
last30DaysChart.data = last30DaysData;
last30DaysChart.update();

const last24HoursChart = new Chart(document.getElementById('last24HoursChart'), chartConfig);
last24HoursChart.data = last24HoursData;
last24HoursChart.update();
document.addEventListener('DOMContentLoaded', function () {
                // Create chart
    var ageChart = new Chart(ctxAge, {
        type: 'bar',
        data: {
            labels: Object.keys(ageDistributionData),
            datasets: [{
            label: 'Number of Students',
            data: Object.values(ageDistributionData),
            backgroundColor: 'green'
            }]
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        var ctxDepartment = document.getElementById('departmentChart').getContext('2d');

        if (!ctxDepartment) {
            throw new Error('Canvas context not found');
        }

        var departmentChart = new Chart(ctxDepartment, {
            type: 'pie',
            data: {
                labels: deptkey,
                datasets: [{
                    data: deptdata,
                    backgroundColor: ['red', 'green', 'blue', 'orange', 'purple']
                }]
            }
        });
    } catch (error) {
        console.error('Error creating pie chart:', error);
    }
});
//gender

document.addEventListener('DOMContentLoaded', function () {
    try {
        var ctxGender = document.getElementById('genderChart').getContext('2d');

        if (!ctxGender) {
            throw new Error('Canvas context not found');
        }

        var genderChart = new Chart(ctxGender, {
            type: 'pie',
            data: {
                labels: gnderlabel,
                datasets: [{
                    data: genderdata,
                    backgroundColor: ['red', 'green', 'blue']
                }]
            }
        });
    } catch (error) {
        console.error('Error creating pie chart:', error);
    }
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        var ctxDegree = document.getElementById('degreeChart').getContext('2d');

        if (!ctxDegree) {
            throw new Error('Canvas context not found');
        }

        var degreeChart = new Chart(ctxDegree, {
            type: 'pie',
            data: {
                labels: degreelabel,
                datasets: [{
                    data: degreedata,
                    backgroundColor: ['red', 'green', 'blue', 'orange', 'purple']
                }]
            }
        });
    } catch (error) {
        console.error('Error creating pie chart:', error);
    }
});



var provincialChart = new Chart(ctxProvincial, {
    type: 'pie',
    data: {
        labels: Object.keys(provincialData),
        datasets: [{
            data: Object.values(provincialData),
            backgroundColor: ['red', 'green', 'blue', 'orange', 'purple']
        }]
    }
});

var submissionChart = new Chart(ctxSubmission, {
    type: 'line',
    data: {
        labels: ['Day 1', 'Day 2', 'Day 3', 'Day 4', 'Day 5'],
        datasets: [{
            label: 'Submissions',
            data: ctxdata,
            borderColor: 'blue',
            borderWidth: 2,
            fill: false
        }]
    }
});