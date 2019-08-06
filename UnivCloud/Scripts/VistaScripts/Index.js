

function deshabilitaRetroceso() {
    window.location.hash = "Again-No-back-button" //chrome
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
}
let MyChart = document.getElementById('MyChart').getContext('2d');
Chart.defaults.global.defaultFontSize = 16;
let Bar = new Chart(MyChart, {
    type: 'bar',
    data: {
        labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        datasets: [{
            labels: 'Population',
            data: [100, 92, 12, 32, 70, 54, 09, 63, 68, 89, 11, 25],
            backgroundColor: [
                '#17A2B8',
                '#3863FF',
                '#17A2B8',
                '#3259E6',
                '#2A4ABF',
                '#3863FF',
                '#3863FF',
                '#17A2B8',
                '#3259E6',
                '#3259E6',
                '#2A4ABF',
                '#17A2B8',

            ],
            borderWidth: 1,
            borderColor: '#777',
            hoverBorderWidth: 3,
            hoverBorderColor: '#888'
        }]
    },
    options: {
        title: {
            display: true,
            text: 'Estado de ventas',
            fontSize: 24
        }
    }
})