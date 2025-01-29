document.addEventListener("click", function(event) {
    event.preventDefault();
    let selector = getSelector(event.target);

    fetch("http://localhost:5000/capture", {
        method: "POST",
        headers: {
            "Content-Type": "text/plain"
        },
        body: selector
    })
    .then(response => response.text())
    .then(data => console.log("Resposta do servidor:", data))
    .catch(error => console.error("Erro ao enviar seletor:", error));
});

function getSelector(element) {
    let path = [];
    while (element.parentElement) {
        let tag = element.tagName.toLowerCase();
        let siblings = Array.from(element.parentElement.children).filter(el => el.tagName.toLowerCase() === tag);
        let index = siblings.indexOf(element) + 1;
        path.unshift(index > 1 ? `${tag}:nth-of-type(${index})` : tag);
        element = element.parentElement;
    }
    return path.join(" > ");
}
