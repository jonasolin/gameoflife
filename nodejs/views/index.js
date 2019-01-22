const size = 200;
const canvas = document.getElementById('gameoflife_canvas');
const context = canvas.getContext('2d');
context.fillStyle = '#000000';
context.canvas.width = size;
context.canvas.height = size;

function createStartingGrids() {
    for (var i = 0; i <= size; i++) {
        gol.cells[i] = [];
        gol.nextGenerationCells[i] = [];
    }
}

function setRandomStartValues() {
    for (var i = (size / 10); i < size - (size / 10); i++) {
        for (var j = (size / 10); j < size - (size / 10); j++) {
            gol.cells[i][j] = Math.round(Math.random());
        }
    }
}

function drawStartingCanvas() {
    context.clearRect(0, 0, size, size);
    for (var i = 0; i <= size; i++) {
        for (var j = 0; j <= size; j++) {
            if (gol.cells[i][j] === 1) {
                context.fillRect(i, j, 1, 1);
            }
        }
    }
};

function live() {
    drawStartingCanvas();
    updateLife();
    requestAnimationFrame(live);
};

function updateLife() {
    for (var i = 1; i < size - 1; i++) {
        for (var j = 1; j < size - 1; j++) {
            gol.nextGenerationCells[i][j] = gol.getNextLivingStatus(i, j);
        }
    }

    var temp = gol.cells;
    gol.cells = gol.nextGenerationCells;
    gol.nextGenerationCells = temp;
};

createStartingGrids();
setRandomStartValues();
live();