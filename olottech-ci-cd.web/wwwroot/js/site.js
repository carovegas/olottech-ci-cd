function isAdult() {
    const fetchConfig = {
        method: 'GET'
    };

    const port = window.location.port !== "" ? `:${window.location.port}` : "";
    const protocol = window.location.protocol.includes("https") ? 'https' : 'http';

    let age = document.getElementById('age').value;

    const url = `${protocol}://${window.location.hostname}${port}/home/${age}/isadult`;

    fetch(url, fetchConfig)
        .then(result => result.json())
        .then(result =>
        {
            document
                .getElementById('result')
                .innerHTML = result.isAdult;
        });
}