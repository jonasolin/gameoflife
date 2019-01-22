const gol = {
    cells: [],
    nextGenerationCells: []
};

gol.getNextLivingStatus = function (i, j) {
    const livingNeighbors = gol.getLivingNeighbors(i, j);

    if (livingNeighbors === 2) {
        return gol.cells[i][j];
    }

    if (livingNeighbors === 3) {
        return 1;
    }

    return 0;
};

gol.getLivingNeighbors = function (i, j) {
    var livingNeighbors = 0;
    livingNeighbors += gol.cells[i - 1][j - 1];
    livingNeighbors += gol.cells[i - 1][j];
    livingNeighbors += gol.cells[i - 1][j + 1];
    livingNeighbors += gol.cells[i][j - 1];
    livingNeighbors += gol.cells[i][j + 1];
    livingNeighbors += gol.cells[i + 1][j - 1];
    livingNeighbors += gol.cells[i + 1][j];
    livingNeighbors += gol.cells[i + 1][j + 1];
    return livingNeighbors;
};

module.exports = gol;