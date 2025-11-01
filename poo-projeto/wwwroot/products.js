async function loadProducts() {
    try {
        const response = await fetch('/products');
        const products = await response.json();
        const tbody = document.querySelector('#productsTable tbody');

        products.forEach(product => {
            const row = document.createElement('tr');

            const idCell = document.createElement('td');
            idCell.textContent = product.id;
            row.appendChild(idCell);

            const nameCell = document.createElement('td');
            nameCell.textContent = product.name;
            row.appendChild(nameCell);

            const priceCell = document.createElement('td');
            priceCell.textContent = product.price.toFixed(2);
            row.appendChild(priceCell);

            tbody.appendChild(row);
        });
    } catch (error) {
        console.error('Erro ao carregar produtos:', error);
    }
}

window.onload = loadProducts;