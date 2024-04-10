window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
})

const functionAPI = '';

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