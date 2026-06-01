const apiUrl = '/api/computers';
const tableBody = document.getElementById('tableBody');
const addForm = document.getElementById('addComputerForm');

// 1. READ
async function fetchComputers() {
    const response = await fetch(apiUrl);
    const computers = await response.json();

    tableBody.innerHTML = '';

    computers.forEach(pc => {
        let statusColor = pc.status === 'Free' ? '#00ffcc' : pc.status === 'InGame' ? '#ffcc00' : '#ff3366';

        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${pc.id}</td>
            <td><strong>${pc.name}</strong></td>
            <td><span class="status-badge" style="background-color: ${statusColor}20; color: ${statusColor}">${pc.status}</span></td>
            <td>Зона ${pc.zoneId}</td>
            <td><button class="btn-delete" onclick="deleteComputer(${pc.id})">Видалити</button></td>
        `;
        tableBody.appendChild(row);
    });
}

// 2. CREATE
addForm.addEventListener('submit', async (e) => {
    e.preventDefault();

    const newComputer = {
        name: document.getElementById('name').value,
        status: document.getElementById('status').value,
        zoneId: parseInt(document.getElementById('zoneId').value)
    };

    await fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newComputer)
    });

    addForm.reset();
    fetchComputers(); 
});

// 3. DELETE
async function deleteComputer(id) {
    if (confirm('Ви точно хочете видалити цей ПК?')) {
        await fetch(`${apiUrl}/${id}`, {
            method: 'DELETE'
        });
        fetchComputers();
    }
}
fetchComputers();