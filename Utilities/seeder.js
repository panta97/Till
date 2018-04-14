
function seddingTallyEarnings() {
  let tallyId = 1;
  for (let i = 0; i < 60; i++) {
    const relativeIndex = mod(i, 11);

    console.log('INSERT INTO `mauwi`.`TallyEarnings` (`EarningId`, `TallyId`) VALUES (' + `'${i + 1}'` + ', ' + `'${tallyId}'` + ');');
    if ((i + 1) % 12 === 0) {
      tallyId++;
    }
  }
}

function seddingTallyExpenses() {
  let tallyId = 1;
  for (let i = 0; i < 60; i++) {
    const relativeIndex = mod(i, 11);

    console.log('INSERT INTO `mauwi`.`TallyExpenses` (`ExpenseId`, `TallyId`) VALUES (' + `'${i + 1}'` + ', ' + `'${tallyId}'` + ');');
    // INSERT INTO `mauwi`.`TallyExpenses` (`ExpenseId`, `TallyId`) VALUES ('1', '1');

    if ((i + 1) % 12 === 0) {
      tallyId++;
    }
  }
}

function seedingEarnings() {
  let tallyId = 1;
  for (let i = 0; i < 60; i++) {
    
    console.log('UPDATE `mauwi`.`Earnings` SET `TallyId`='+`'${tallyId}'`+' WHERE `Id`='+`'${i + 1}'`+';');

    if ((i + 1) % 12 === 0) {
      tallyId++;
    }
  }
}
function seedingExpenses() {
  let tallyId = 1;
  for (let i = 0; i < 60; i++) {
    
    console.log('UPDATE `mauwi`.`Expenses` SET `TallyId`='+`'${tallyId}'`+' WHERE `Id`='+`'${i + 1}'`+';');
    if ((i + 1) % 12 === 0) {
      tallyId++;
    }
  }
}


function seedAll() {
  seddingTallyEarnings();
  seddingTallyExpenses();
  seedingEarnings();
  seedingExpenses();
}

seedAll();

function mod(relative, length) {
  // length ++;
  relative++;

  if (relative === length || relative % length === 0) {
    return length - 1;
  }

  return (relative % length) - 1;
}

// console.log(mod(21, 11));


function seddingEarnings(amount) {

  const denomintaions = [0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200, 1];

  for (let index = 0; index < amount; index++) {

    const amount = Math.floor((Math.random() * 1000) + 1);
    const denomIndex = mod(index, denomintaions.length)
    const type = (index + 1) % denomintaions.length === 0 ? 'tarjeta' : 'efectivo';

    console.log('INSERT INTO `mauwi`.`Earnings` (`Amount`, `Denomination`, `TallyId`, `Type`) VALUES (' + `'${amount}'` + ', ' + `'${denomintaions[denomIndex]}'` + ', ' + `'0'` + ', ' + `'${type}'` + ');');

  }
  // console.log('INSERT INTO `mauwi`.`Earnings` (`Amount`, `Denomination`, `TallyId`, `Type`) VALUES ('+89.0+', '+0.9+', '+0+', '+'efectivo'+');');
}





// let amount = Math.floor( Math.random() * 10);
// for (let index = 0; index < 100; index++) {
//   amount = Math.floor( (Math.random() * 1000) + 1);
//   console.log(amount);

// }