const assert = require('assert');
const gameoflife = require('./views/gameoflife.js');

describe('Game of life tests', function () {
    beforeEach(() => {
        gameoflife.cells = [];
        for (var i = 0; i <= 3; i++) {
            gameoflife.cells[i] = [];
        }
    });

    function logGameOfLife() {
        for (var i = 0; i <= 2; i++) {
            console.log(gameoflife.cells[i]);
        };
    };

    describe('Any live cell with fewer than two live neighbors', () => {
        it('dies, as if by underpopulation', () => {
            gameoflife.cells[0][0] = 0;
            gameoflife.cells[0][1] = 0;
            gameoflife.cells[0][2] = 0;
            gameoflife.cells[1][0] = 0;
            gameoflife.cells[1][1] = 1;
            gameoflife.cells[1][2] = 0;
            gameoflife.cells[2][0] = 0;
            gameoflife.cells[2][1] = 0;
            gameoflife.cells[2][2] = 0;
            logGameOfLife();
            assert.equal(gameoflife.getNextLivingStatus(1, 1), 0);
        });
    });

    describe('Any live cell with two or three live neighbors', () => {
        describe('with two live neighbors', () => {
            it('lives on to the next generation', () => {
                gameoflife.cells[0][0] = 1;
                gameoflife.cells[0][1] = 0;
                gameoflife.cells[0][2] = 1;
                gameoflife.cells[1][0] = 0;
                gameoflife.cells[1][1] = 1;
                gameoflife.cells[1][2] = 0;
                gameoflife.cells[2][0] = 0;
                gameoflife.cells[2][1] = 0;
                gameoflife.cells[2][2] = 0;
                logGameOfLife();
                assert.equal(gameoflife.getNextLivingStatus(1, 1), 1);
            });
        });
        
        describe('with three live neighbors', () => {
            it('lives on to the next generation', () => {
                gameoflife.cells[0][0] = 1;
                gameoflife.cells[0][1] = 1;
                gameoflife.cells[0][2] = 1;
                gameoflife.cells[1][0] = 0;
                gameoflife.cells[1][1] = 1;
                gameoflife.cells[1][2] = 0;
                gameoflife.cells[2][0] = 0;
                gameoflife.cells[2][1] = 0;
                gameoflife.cells[2][2] = 0;
                logGameOfLife();
                assert.equal(gameoflife.getNextLivingStatus(1, 1), 1);
            });
        });
    });

    describe('Any live cell with more than three live neighbors', function () {
        it('dies, as if by overpopulation', () => {
            gameoflife.cells[0][0] = 1;
            gameoflife.cells[0][1] = 1;
            gameoflife.cells[0][2] = 1;
            gameoflife.cells[1][0] = 1;
            gameoflife.cells[1][1] = 1;
            gameoflife.cells[1][2] = 0;
            gameoflife.cells[2][0] = 0;
            gameoflife.cells[2][1] = 0;
            gameoflife.cells[2][2] = 0;
            logGameOfLife();
            assert.equal(gameoflife.getNextLivingStatus(1, 1), 0);
        });
    });

    describe('Any dead cell with exactly three live neighbors', function () {
        it('becomes a live cell, as if by reproduction', () => {
            gameoflife.cells[0][0] = 1;
            gameoflife.cells[0][1] = 1;
            gameoflife.cells[0][2] = 1;
            gameoflife.cells[1][0] = 0;
            gameoflife.cells[1][1] = 0;
            gameoflife.cells[1][2] = 0;
            gameoflife.cells[2][0] = 0;
            gameoflife.cells[2][1] = 0;
            gameoflife.cells[2][2] = 0;
            logGameOfLife();
            assert.equal(gameoflife.getNextLivingStatus(1, 1), 1);
        });
    });
});
