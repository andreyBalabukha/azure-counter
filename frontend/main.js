window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
})

const functionAPI = 'https://azurecounterapp.azurewebsites.net/api/Counter?code=F-0W5N1NeQVWK2V3p1bbbOQQPfUgwCMr36pUnT8iuiqYAzFulNMwGA==';

const getVisitCount = () => {
    let count = 30;
    fetch(functionAPI).then(res => {
        return res.json()
    }).then(res => {
        console.log( 'call was made ');
        count = res.count;
        document.getElementById("counter").innerText = count;
    }).catch(err => {
        console.error( 'error ', err);
    })
};