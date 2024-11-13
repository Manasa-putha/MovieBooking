import { TestBed } from '@angular/core/testing';

import { ToasrrService } from './toasrr.service';

describe('ToasrrService', () => {
  let service: ToasrrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ToasrrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
